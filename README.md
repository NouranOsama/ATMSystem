# ATMSystem

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-15-blue)
![Build](https://img.shields.io/badge/build-passing-brightgreen)

---

## 💡 Tagline
**Secure, Reliable, and Efficient ATM System**

---

## 📖 Project Description

**ATMSystem** is a modern ATM solution designed to handle secure multi-user banking operations.  
It supports deposits, withdrawals, account management, and transaction history tracking.  

**Technologies & Architecture:**
- **C# & .NET** for backend logic
- **EF Core (Code-First)** for database migrations
- **Repository Pattern** for clean separation of concerns
- **PostgreSQL** for data storage
- **Audit logging & transaction isolation** for security

---

## 🛠 Features

| Feature | Description |
|---------|-------------|
| Secure Transactions | Handles deposits, withdrawals, and transfers safely |
| Multi-User Support | Supports multiple customers and accounts |
| Account Management | Create, update, view account details |
| ATM Operations | Withdraw, deposit, check balance, transaction history |
| Transaction Logging | Full audit trail for accountability |
| Repository Pattern | Clean modular architecture |
| Code-First EF Core | Easy schema migrations |
| PostgreSQL Integration | Reliable relational database storage |

---

## 🏗 System Architecture

[User / ATM Console]
│
▼
[API / Service Layer]
│
▼
[Repository Layer]
│
▼
[PostgreSQL Database]

markdown
Copy
Edit

- **Models:** Customer, Account, Card, Transaction, ATM  
- **Repositories:** Interfaces & implementations for each model  
- **Services:** Business logic & operations  
- **Database:** PostgreSQL with EF Core Code-First migrations  

---

## ⚙ Installation & Setup

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 15](https://www.postgresql.org/download/)
- Visual Studio 2022 or later

### Steps
```bash
git clone https://github.com/YourUsername/ATMSystem.git
cd ATMSystem
Create PostgreSQL database: atm_system

Copy appsettings.example.json → appsettings.json and configure connection string:

json
Copy
Edit
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=atm_system;Username=YOUR_USERNAME;Password=YOUR_PASSWORD"
  }
}
Build & run:

bash
Copy
Edit
dotnet build
dotnet run
Run migrations:

bash
Copy
Edit
dotnet ef database update
🖥 Usage
🧪 Test Cases
✅ First Transaction
csharp
Copy
Edit
atm.Deposit(101, 500);
atm.Withdraw(101, 200);
Terminal output:
yaml
Copy
Edit
Account 101: Deposit successful. New balance: 1500
Account 101: Withdrawal successful. New balance: 1300
✅ Second Transaction
csharp
Copy
Edit
atm.Withdraw(102, 1000);
Terminal output:
javascript
Copy
Edit
Error: Insufficient balance in account 102
✅ Third Transaction
csharp
Copy
Edit
atm.Transfer(101, 102, 200);
Terminal output:
yaml
Copy
Edit
Transfer successful: 200 from account 101 to account 102
Account 101: Balance 1100
Account 102: Balance 1200
✅ Fourth Transaction
csharp
Copy
Edit
atm.Deposit(103, 1000);
atm.Withdraw(103, 500);
atm.Transfer(103, 101, 300);
Terminal output:
yaml
Copy
Edit
Account 103: Deposit successful. New balance: 1000
Account 103: Withdrawal successful. New balance: 500
Transfer successful: 300 from account 103 to account 101
Account 103: Balance 200
Account 101: Balance 1400
✅ Fifth Transaction
csharp
Copy
Edit
atm.Withdraw(104, 50);
Terminal output:
javascript
Copy
Edit
Error: Account 104 does not exist
🔒 Security Considerations
Encryption: Sensitive data is encrypted in PostgreSQL

Audit Logging: Logs every transaction

Transaction Isolation: Prevents conflicts between concurrent operations

Secure Authentication: Only authorized users can access accounts

