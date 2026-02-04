# Shop_Apple_HNT
## Giới thiệu
**Shop_Apple_HNT là một ứng dụng web bán hàng được xây dựng theo mô hình **ASP.NET Core MVC, hỗ trợ các chức năng cơ bản như:
- Quản lý sản phẩm, danh mục, thương hiệu
- Đăng nhập, phân quyền người dùng
- Giỏ hàng và đặt hàng
- Khu vực quản trị (Admin)
Dự án được phát triển nhằm mục đích học tập và thực hành xây dựng website thương mại điện tử bằng ASP.NET Core.
## Công nghệ sử dụng
### Môi trường phát triển
- Hệ điều hành: Microsoft Windows 11  
- Cấu hình máy tính:
  - CPU: Intel® Core™ i5-11400  
  - RAM: 16 GB  
  - GPU: Intel UHD Graphics 730  
### Nền tảng & Công cụ
- Backend: ASP.NET Core MVC 9.0.12
- Frontend: Bootstrap 3.0.3
- Cơ sở dữ liệu: Microsoft SQL Server **2025**
- IDE: Visual Studio 2026
- Trình duyệt kiểm thử: Google Chrome, Microsoft Edge
## Yêu cầu hệ thống
Trước khi chạy project, đảm bảo máy đã cài:
- .NET SDK 9.0.x
- Microsoft SQL Server 2025
- Visual Studio 2026 (đã cài workload ASP.NET & web development)
## Hướng dẫn cài đặt & chạy project
### Bước 1: Mở project
1. Mở Microsoft Visual Studio
2. Chọn Open a project or solution
3. Mở file solution (`.sln`) của project Shop_Apple_HNT
### Bước 2: Tạo cơ sở dữ liệu
1. Mở SQL Server
2. Tạo một database mới (ví dụ: `Shop_Apple_HNT`)
3. Copy connection string
4. Dán vào file `appsettings.json`
5. Đổi `Data Source` cho phù hợp với SQL Server trên máy
Ví dụ:json"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Shop_Apple_HNT;Trusted_Connection=True;TrustServerCertificate=True"}
Bước 3: Thực hiện Migration
Chuột phải vào project Shop_Apple_HNT
Chọn Open Terminal
Chuyển sang Package Manager Console
Chạy các lệnh sau:
Add-Migration db
Update-Database
Lệnh trên sẽ tạo bảng và cấu trúc dữ liệu trong SQL Server.
Bước 4: Chạy ứng dụng
Nhấn Run (F5) trong Visual Studio
Truy cập website bằng trình duyệt (Chrome hoặc Edge)
