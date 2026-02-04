Shop_Apple_HNT

Giới thiệu
Shop_Apple_HNT là ứng dụng web bán hàng được xây dựng theo mô hình ASP.NET Core MVC.
Ứng dụng hỗ trợ các chức năng cơ bản như quản lý sản phẩm, danh mục, thương hiệu; đăng nhập và phân quyền người dùng; giỏ hàng, đặt hàng và khu vực quản trị (Admin).
Dự án được thực hiện nhằm mục đích học tập và thực hành xây dựng website thương mại điện tử bằng ASP.NET Core.

Công nghệ sử dụng
Hệ điều hành: Microsoft Windows 11
CPU: Intel® Core™ i5-11400
RAM: 16 GB
GPU: Intel UHD Graphics 730

Nền tảng và công cụ
Backend: ASP.NET Core MVC 9.0.12
Frontend: Bootstrap 3.0.3
Cơ sở dữ liệu: Microsoft SQL Server 2025
IDE: Visual Studio 2026
Trình duyệt kiểm thử: Google Chrome, Microsoft Edge

Yêu cầu hệ thống
Đã cài đặt .NET SDK 9.0.x
Đã cài đặt Microsoft SQL Server 2025
Đã cài đặt Visual Studio 2026 với ASP.NET & Web Development

Hướng dẫn cài đặt và chạy project
Bước 1: Mở project
Mở Microsoft Visual Studio
Chọn Open a project or solution
Mở file solution (.sln) của project Shop_Apple_HNT
Bước 2: Tạo cơ sở dữ liệu
Tạo database mới trong SQL Server (ví dụ: Shop_Apple_HNT)
Cập nhật chuỗi kết nối trong file appsettings.json cho phù hợp với máy
"ConnectionStrings":
"DefaultConnection": "Server=.;Database=Shop_Apple_HNT;Trusted_Connection=True;TrustServerCertificate=True"
Bước 3: Migration database
Mở Package Manager Console
Chạy lệnh Add-Migration db
Chạy lệnh Update-Database
Hệ thống sẽ tự động tạo bảng và cấu trúc dữ liệu trong SQL Server
Bước 4: Chạy ứng dụng
Nhấn Run (F5) trong Visual Studio
Truy cập website bằng trình duyệt Chrome hoặc Edge
