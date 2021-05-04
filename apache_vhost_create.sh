#!/usr/bin/env bash

# Author: Vagelis Prokopiou <vagelis.prokopiou@gmail.com>

# Check for a provided hostname argument.
if [[ ! "$1" ]]; then
  echo "Usage: $0 <hostName>";
  exit 1;
fi

# Make sure the following modules are enabled.
sudo a2enmod headers;
sudo a2enmod proxy;
sudo a2enmod proxy_http;

user="va";
base_path="/home/${user}/www";
domain="$1";
docroot="${base_path}/${domain}/public_html/web";
logsdir="${base_path}/${domain}/logs";

if [[ -d "${base_path}/${domain}" ]]; then
  echo "${domain} already exists. Skipping...";
  exit 0;
fi

sudo mkdir -p "${docroot}";
sudo mkdir -p "${logsdir}";
# Create an index file.
echo "<h1>${domain}.local has been created successfully.</h1>" | sudo tee "${docroot}/index.html";

domainSuffix="local.com";

# Create the Apache config files.
echo "
<VirtualHost *:*>
    RequestHeader set \"X-Forwarded-Proto\" expr=%{REQUEST_SCHEME}
</VirtualHost>
<VirtualHost *:80>
    ProxyPreserveHost On
    ProxyPass / http://127.0.0.1:5000/
    ProxyPassReverse / http://127.0.0.1:5000/
    ServerName ${domain}.local
    ServerAlias www.${domain}.local
    ErrorLog ${logsdir}/error.log
    CustomLog ${logsdir}/access.log combined
</VirtualHost>" | sudo tee "/etc/apache2/sites-available/${domain}.local.conf";

# Enable the site.
sudo a2ensite "${domain}.${domainSuffix}";

# Add the vhost to the vhosts file.
echo "127.0.0.1 ${domain}.${domainSuffix}" | sudo tee --append /etc/hosts;

sudo chown -R va:www-data "${base_path}/${domain}";

# Restart Apache.
sudo systemctl restart apache2;
echo "You can access the site at https://${domain}.${domainSuffix}"; 
