# Manajemen Ruangan – Backend API

Backend API untuk sistem **Manajemen Peminjaman Ruangan** yang dibangun menggunakan **ASP.NET Core Web API** dengan **SQLite** sebagai basis data.  
Aplikasi ini berperan sebagai penyedia layanan RESTful yang digunakan oleh frontend untuk mengelola data peminjaman ruangan.

---

## Tech Stack

- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger / OpenAPI

---

## Fitur Utama

- CRUD data peminjaman ruangan
- Proses approval dan reject peminjaman
- Validasi bentrok waktu peminjaman ruangan
- Seeder data ruangan (read-only)

---

## Data Awal (Seeder Ruangan)

Data ruangan disediakan melalui **seeder** pada database dan bersifat **read-only**.  
Frontend hanya menggunakan data ruangan ini sebagai referensi saat membuat peminjaman.

---

## Arsitektur Singkat

Backend ini menggunakan pendekatan **RESTful API** dengan pembagian layer sebagai berikut:

- **Controller**: Menangani request dan response HTTP
- **Model**: Representasi entitas database
- **DTO**: Struktur data untuk request dan response API
- **DbContext**: Konfigurasi Entity Framework dan database

---

Panduan Menjalankan Aplikasi
1. Menjalankan Migration Database

Pastikan database telah dibuat dan di-update dengan menjalankan:

dotnet ef database update

2. Menjalankan Aplikasi (Development)

Jalankan aplikasi dalam mode development:

dotnet run


Secara default aplikasi akan berjalan di:

http://localhost:5153

Key Endpoints (API Utama)

Berikut endpoint utama yang digunakan oleh frontend:

Ruangan (Read-only)
GET /api/rooms


Digunakan untuk mengambil daftar ruangan dari seeder.

Peminjaman Ruangan
GET    /api/borrowings
POST   /api/borrowings
PUT    /api/borrowings/{id}
DELETE /api/borrowings/{id}


Digunakan untuk:

Menampilkan daftar peminjaman

Membuat peminjaman baru

Mengubah data peminjaman

Menghapus peminjaman

Approval Peminjaman
PUT /api/borrowings/{id}/approve
PUT /api/borrowings/{id}/reject


Digunakan untuk proses persetujuan atau penolakan peminjaman.
