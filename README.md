PartyManager – ASP.NET Core MVC Project

Conestoga College – PROG2231 – Group Project
A data-driven ASP.NET Core MVC application for managing parties, invitations, and guest responses.
Includes authentication, authorization, email sending support, and clean MVC architecture.

🚀 Features
🟦 Party Management

Create, edit, view, and soft-delete parties

Undo delete (Admin only)

Stores description, date, and location

🟩 Invitations

Add/edit/delete invitations for each party

Validate guest email

Tracks RSVP response (Yes/No/Pending)

🔐 Identity / Authentication

Login / Register

Only logged-in users can manage parties and invitations

Admins only can delete and undo delete

💾 Database

EF Core + SQLite

Migrations included

Models with validation attributes (Required, EmailAddress, Date)

✉️ Email Support

Email sample provided (SMTP + Gmail App Password)

Sends invitations to guests with RSVP link

🧱 Tech Stack

ASP.NET Core MVC (net9.0)

Entity Framework Core

SQLite database

Identity authentication

Bootstrap UI

Razor Pages (only for Identity)

📂 Project Structure
PartyManager/
│── Controllers/
│── Models/
│── Views/
│── Data/
│── Migrations/
│── wwwroot/
│── appsettings.json   (ignored in Git)
│── PartyManager.csproj

🛠 Setup Instructions
1️⃣ Clone the repository
git clone https://github.com/harkamaltoor-spec/-PartyManager.git
cd PartyManager

2️⃣ Restore packages
dotnet restore

3️⃣ Apply migrations
dotnet ef database update

4️⃣ Run the project
dotnet run

👨‍💻 Team Members & Responsibilities
Student 1 — Harkamal Toor

Created repository

Setup project structure

Added Party model

Added Invitation model

Added Entity Framework + SQLite

Added database migrations

Created basic Party CRUD

Created Invitation Create page

Fixed hidden PartyId issue

Connected Views + Controllers

GitHub setup + .gitignore setup

Student 2

(to be filled by your teammate)

Student 3

(to be filled by your teammate)

Student 4

(to be filled by your teammate)

🧪 Unit Testing

Each member must write 1 automated test.
Suggested areas:

Party creation

Invitation creation

RSVP update

Soft delete + Undo delete

📧 Email Setup (Optional for Demo)

Inside appsettings.json (not pushed to GitHub):

"Smtp": {
  "Host": "smtp.gmail.com",
  "Port": 587,
  "Username": "REPLACE",
  "Password": "REPLACE"
}

👍 Status

✔ Core features working
✔ Identity working
✔ GitHub repository ready
⬜ Invitations email + RSVP
⬜ Dashboard stats
⬜ Unit tests
⬜ Final demo slides

🎯 Git Workflow (For team — copy this to README or send to group chat)
🔄 Git Workflow for Group

Simple rules to avoid merge conflicts and keep code clean.

1️⃣ Every student creates their own branch
git checkout -b student2-invitations
git checkout -b student3-email
git checkout -b student4-response


Never work directly on main.

2️⃣ Before working, always pull latest code
git checkout main
git pull origin main

3️⃣ Make changes on your branch
git checkout student2-invitations


After coding:

git add .
git commit -m "Added invitations controller actions"
git push -u origin student2-invitations

4️⃣ Create a Pull Request (PR) on GitHub

Your team reviews and merges it into main.

5️⃣ After merge, update your local main
git checkout main
git pull origin main

