using Microsoft.EntityFrameworkCore;
using Shop_Apple_HNT.Models;

namespace Shop_Apple_HNT.Repository
{
    public class SeedData
    {
        public static void SeedingData(DataContext _context)
        {
            _context.Database.Migrate();

            if (!_context.SanPhams.Any())
            {
                // ===== DANH MỤC =====
                var macbook = new DanhMucModel { Ten = "Macbook", Slug = "macbook", MoTa = "Macbook Apple", Status = 1 };
                var iphone = new DanhMucModel { Ten = "iPhone", Slug = "iphone", MoTa = "Điện thoại Apple", Status = 1 };
                var ipad = new DanhMucModel { Ten = "iPad", Slug = "ipad", MoTa = "Máy tính bảng Apple", Status = 1 };
                var watch = new DanhMucModel { Ten = "Apple Watch", Slug = "apple-watch", MoTa = "Đồng hồ Apple", Status = 1 };
                var airpods = new DanhMucModel { Ten = "AirPods", Slug = "airpods", MoTa = "Tai nghe Apple", Status = 1 };

                // ===== BRAND =====
                var apple = new BrandModel { Ten = "Apple", Slug = "apple", Mota = "Apple", Status = 1 };

                _context.DanhMucs.AddRange(macbook, iphone, ipad, watch, airpods);
                _context.Brands.Add(apple);
                _context.SaveChanges();

                // ===== SẢN PHẨM =====
                _context.SanPhams.AddRange(

                    new SanPhamModel
                    {
                        Ten = "Macbook Air M4 15 inch",
                        Slug = "macbook-air-m4",
                        MoTa = "MacBook Air M4 15 inch sở hữu thiết kế mỏng nhẹ cao cấp với khung nhôm nguyên khối sang trọng. Trang bị chip Apple M4 thế hệ mới mang lại hiệu năng vượt trội, xử lý mượt các tác vụ văn phòng, học tập, lập trình và đồ họa cơ bản. Màn hình Liquid Retina 15.3 inch cho chất lượng hiển thị sắc nét, màu sắc trung thực. Thời lượng pin lên đến 18 giờ đáp ứng tốt nhu cầu làm việc cả ngày dài.",
                        Gia = 28000000,
                        Hinh = "macbook-air-15-inch-m4-vang 28tr-600x600.jpg",
                        DanhMuc = macbook,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "Macbook Pro M5 14 inch",
                        Slug = "macbook-pro-m5",
                        MoTa = "MacBook Pro M5 14 inch là dòng laptop cao cấp dành cho người dùng chuyên nghiệp. Trang bị chip M5 mạnh mẽ, xử lý mượt mà các tác vụ đồ họa nặng, dựng video 4K, lập trình và AI. Màn hình Liquid Retina XDR cho độ sáng cao, màu sắc chính xác. Hệ thống tản nhiệt tối ưu giúp duy trì hiệu suất ổn định trong thời gian dài.",
                        Gia = 42000000,
                        Hinh = "macbook-pro-14-inch-m5-16gb-512gb-thumb 42tr-638962954605863722-600x600.jpg",
                        DanhMuc = macbook,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "iPhone 15",
                        Slug = "iphone-15",
                        MoTa = "iPhone 15 được trang bị chip A16 Bionic cho hiệu năng vượt trội, tiết kiệm năng lượng. Màn hình OLED 6.1 inch hiển thị sắc nét, sống động. Hệ thống camera cải tiến cho chất lượng ảnh chụp và quay video ấn tượng trong mọi điều kiện ánh sáng. Thiết kế cao cấp, pin bền bỉ và hệ điều hành iOS ổn định, bảo mật cao.",
                        Gia = 19000000,
                        Hinh = "iphone-15-xanh-thumb-600x600.jpg",
                        DanhMuc = iphone,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "iPhone 16 Pro",
                        Slug = "iphone-16-pro",
                        MoTa = "iPhone 16 Pro sở hữu thiết kế khung titan cao cấp, màn hình Super Retina XDR 120Hz mượt mà. Chip A18 Pro mang lại hiệu suất mạnh mẽ, tối ưu cho gaming, xử lý hình ảnh và quay video chuẩn điện ảnh. Cụm camera chuyên nghiệp hỗ trợ zoom quang học và quay video ProRes, đáp ứng nhu cầu sáng tạo nội dung cao cấp.",
                        Gia = 29000000,
                        Hinh = "iphone-16-pro-tu-nhien-thumb-600x600.jpg",
                        DanhMuc = iphone,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "iPhone 17 Pro Max",
                        Slug = "iphone-17-pro-max",
                        MoTa = "iPhone 17 Pro Max là flagship mạnh mẽ nhất của Apple với màn hình lớn 6.9 inch, pin dung lượng cao và chip A19 Pro hiệu năng vượt trội. Hệ thống camera nâng cấp với cảm biến lớn cho khả năng chụp thiếu sáng xuất sắc. Phù hợp cho người dùng cao cấp, doanh nhân và người sáng tạo nội dung.",
                        Gia = 35000000,
                        Hinh = "iphone-17-pro-max-cam-thumb-600x600.jpg",
                        DanhMuc = iphone,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "iPad Mini 7",
                        Slug = "ipad-mini-7",
                        MoTa = "iPad Mini 7 sở hữu thiết kế nhỏ gọn, màn hình Liquid Retina 8.3 inch sắc nét, hỗ trợ Apple Pencil thế hệ mới. Chip A17 Bionic cho hiệu năng mạnh mẽ, phù hợp học tập, ghi chú, đọc sách, giải trí và làm việc linh hoạt mọi lúc mọi nơi.",
                        Gia = 14000000,
                        Hinh = "ipad-mini-7 14tr-wifi-purple-thumb-600x600.jpg",
                        DanhMuc = ipad,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "iPad Pro M5",
                        Slug = "ipad-pro-m5",
                        MoTa = "iPad Pro M5 được trang bị chip Apple M5 siêu mạnh, màn hình Liquid Retina XDR 120Hz cho chất lượng hiển thị đỉnh cao. Hỗ trợ Apple Pencil Pro và Magic Keyboard, biến iPad thành công cụ làm việc và sáng tạo chuyên nghiệp cho designer, kiến trúc sư và lập trình viên.",
                        Gia = 30000000,
                        Hinh = "ipad-pro-m5-wifi 30tr-11-inch-black-thumb-600x600.jpg",
                        DanhMuc = ipad,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "Apple Watch Series 11",
                        Slug = "apple-watch-11",
                        MoTa = "Apple Watch Series 11 mang đến trải nghiệm theo dõi sức khỏe toàn diện với cảm biến đo nhịp tim, ECG, SpO2 và theo dõi giấc ngủ nâng cao. Thiết kế hiện đại, màn hình Always-On sắc nét, pin tối ưu và khả năng kết nối mạnh mẽ giúp quản lý công việc, luyện tập và sức khỏe hiệu quả.",
                        Gia = 21000000,
                        Hinh = "apple-watch-series-11.jpg",
                        DanhMuc = watch,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "AirPods 4",
                        Slug = "airpods-4",
                        MoTa = "AirPods 4 mang đến chất lượng âm thanh sống động, bass mạnh, hỗ trợ chống ồn chủ động ANC và xuyên âm. Chip H3 giúp kết nối nhanh chóng, ổn định. Thiết kế nhỏ gọn, pin lâu và sạc nhanh qua MagSafe, phù hợp cho học tập, làm việc và giải trí.",
                        Gia = 6000000,
                        Hinh = "hinh2.jpg",
                        DanhMuc = airpods,
                        Brand = apple
                    },

                    new SanPhamModel
                    {
                        Ten = "Apple Watch SE GPS",
                        Slug = "apple-watch-se",
                        MoTa = "Apple Watch SE GPS là lựa chọn hoàn hảo với mức giá hợp lý, vẫn đáp ứng đầy đủ các tính năng theo dõi sức khỏe, luyện tập, thông báo và gọi điện. Thiết kế trẻ trung, màn hình Retina sắc nét, pin ổn định, phù hợp với học sinh, sinh viên và người dùng phổ thông.",
                        Gia = 9000000,
                        Hinh = "apple-watch-se-3.jpg",
                        DanhMuc = watch,
                        Brand = apple
                    }

                );

                _context.SaveChanges();
            }
        }
    }
}
