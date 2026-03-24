# upGrad Virtual Event Management System

A complete front-end EMS project built with HTML5, CSS3, Bootstrap 5, and JavaScript using IndexedDB for local data storage.

## Tech Stack
- HTML5
- CSS3
- Bootstrap 5
- JavaScript (ES6)
- IndexedDB

## Users
1. Participant
- Explore upcoming events on Home page
- Register for an event
- Contact organization from Contact Us page

2. Admin
- Login with JavaScript authentication
- Add events
- View events as cards
- Delete events
- Search by ID, name, and category
- Logout

## Admin Credentials
- Email: `admin@upgrad.com`
- Password: `12345`

## Pages
- `index.html` - Home page with existing events and Register buttons
- `login.html` - Admin login page
- `events.html` - Protected admin dashboard with CRUD and search
- `register.html` - Participant event registration page
- `contact.html` - Contact form page

## Features Implemented
- Responsive Bootstrap navbar and layouts
- Dynamic event cards with Join Event links
- IndexedDB local persistence for Create/Read/Delete
- Search by event ID, name, and category
- Route protection for `events.html`
- Logout support
- Client-side form validation (`required`, `email`, `url`, `date`, regex pattern)
- Success and error alerts

## Project Structure
```
event management/
|-- index.html
|-- login.html
|-- events.html
|-- register.html
|-- contact.html
|-- css/
|   `-- styles.css
|-- js/
|   |-- common.js
|   |-- auth.js
|   |-- db.js
|   |-- home.js
|   |-- login.js
|   |-- events.js
|   |-- register.js
|   `-- contact.js
`-- README.md
```

## How to Run
1. Open folder in VS Code.
2. Run with Live Server (recommended) or open `index.html` in browser.
3. Navigate using navbar.

## Manual Test Checklist
- Login validation working
- Unauthorized direct access protection working
- Add event working
- Delete event working
- Search by ID/name/category working
- Register flow working
- Contact form validation working
- No broken links between pages
