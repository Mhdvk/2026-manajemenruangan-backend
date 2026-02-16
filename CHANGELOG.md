# Changelog

All notable changes to this backend project will be documented in this file.
This project follows Semantic Versioning (SemVer).

---

## [0.2.0] – 2026-02-16
### Added
- Contoh file environment (`.env.example`).
- Konfigurasi ignore file environment agar tidak ter-track oleh Git.
- Penambahan nama ruangan pada DTO peminjaman agar dapat dikirim ke Front End.

### Changed
- Revisi dokumentasi README backend agar lebih jelas dan terstruktur.
- Update seeder data ruangan pada database.

### Fixed
- Perbaikan konfigurasi CORS pada `Program.cs` untuk mengatasi masalah cross-origin.
- Perbaikan konflik merge pada `RoomBorrowingController`.
- Perbaikan logic edit status peminjaman ruangan.

---

## [0.1.1] – 2026-02-11
### Added
- Kolom **Tujuan** pada entitas `RoomBorrowing`.
- Update DTO (Create & Update) untuk mendukung field **Tujuan**.
- Endpoint **GET RoomBorrowing by ID** menampilkan data Tujuan.
- Endpoint **PUT RoomBorrowing** dapat melakukan update Tujuan.
- Contoh JSON request untuk pengujian fitur Tujuan.

---

## [0.1.0] – 2026-02-11
### Added
- Seeder data ruangan.
- Endpoint approval dan reject peminjaman ruangan.
- Validasi bentrok waktu peminjaman ruangan.

### Changed
- Endpoint **Rooms** menjadi read-only.

---

## [0.0.0] – 2026-02-08
### Added
- Setup awal backend menggunakan ASP.NET Core.
- CRUD peminjaman ruangan.
- Konfigurasi SQLite, models, dan initial migration.
