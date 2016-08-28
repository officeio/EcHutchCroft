# E.C Hutchcroft Website
http://echutchcroft.com/

## Settings
Settings are stored in the `settings.json` file. They mostly comprise of SMTP settings to send emails from the website.

## User Secrets
The username and password for the SMTP server is not stored in the `settings.json` file, as this would be a bad idea. Instead anyone running this code will have to place the credentials into a secrets.json file inside their user-profile directory.

## Testimonials
Testimonials are shown on the home page, and are stored inside the `Testimonials` folder. 
They are displayed in alphabetical order of the filenames inside the folder.

### Markdown
Each `.md` file uses *Markdown* notation. It is used as a way of writing plain-text that when displayed onto a webpage will be formatted.

Feel free to use this [reference](http://commonmark.org/help/) as a notation cheat-sheet.