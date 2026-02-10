# Manajemen Ruangan - Backend

Backend API untuk sistem manajemen peminjaman ruangan
menggunakan ASP.NET Core Web API dan SQLite.

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

## Fitur
- CRUD Peminjaman Ruangan
- Approval & Reject Peminjaman
- Validasi bentrok waktu peminjaman
- Seeder data Ruangan

## Data Awal (Seeder)
Data ruangan disediakan melalui seeder (read-only).
Frontend hanya menggunakan data ini.

## Panduan Menjalankan Aplikasi

1. Jalankan Migration
dotnet ef database update

2. Jalankan Aplikasi
dotnet run

3. Akses API
Buka browser dan akses Swagger UI:
http://localhost:5xxx/swagger

Swagger digunakan untuk mencoba dan menguji seluruh endpoint API.

