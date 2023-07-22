using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ArticleContent = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategories",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategories", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("12428f09-81f2-49d7-985f-6bc0a0da015a"), "Thông tin mới nhất về các môn thể thao trên toàn thế giới", "Thể Thao", "the-thao" },
                    { new Guid("5ab04e34-3529-4984-bb90-f707691c5542"), "Công nghệ và những vấn đề liên quan đến công nghệ", "Công nghệ", "cong-nghe" },
                    { new Guid("7593f61e-2eba-484d-8904-ddbd5ea07449"), "Xoay quanh những vấn đề đáng được quan tâm trong xã hội", "Xã hội", "xa-hoi" },
                    { new Guid("7fef1bb3-0bac-4be9-ab94-c8c817cf1a3d"), "Các vấn đề nhức nhối, thành tựu nổi bật trong giới chính trị", "Chính trị", "chinh-tri" },
                    { new Guid("867cc1c4-ecba-403d-84d5-9dee111567a7"), "Các thống kê và báo cáo về tình hình kinh tế trong nước và thế giới", "Kinh tế", "kinh-te" },
                    { new Guid("8d29ed4f-5f51-452d-9ca0-1a90f6be2213"), "Vài vòng qua thế giới của tri thức và giáo dục", "Giáo dục", "giao-duc" },
                    { new Guid("a50e1f05-b24a-4555-a043-0fa3b8e01ce4"), "Những câu chuyện về cuộc sống thường nhật", "Đời sống", "doi-song" },
                    { new Guid("bbd033f7-c6d9-4029-8217-1ba6aa59b724"), "Những tin tức nóng hổi, cập nhật mới nhất trong giới Showbiz", "Showbiz", "showbiz" },
                    { new Guid("c89df401-4192-47e5-8608-bacd9bb4d0b3"), "Những tác phẩm nổi tiếng và tin bài về những nghệ sĩ ưu tú", "Nghệ thuật", "nghe-thuat" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("481d5ff4-d4d8-46c0-b356-898097c2c3c9"), "ffe9157c-e510-44ff-93f4-a0fd02901681", "User", "USER" },
                    { new Guid("55ab95a7-8830-4eb9-966a-2196880296b4"), "4f8d9256-9479-4f19-b209-495871700cc8", "Admin", "ADMIN" },
                    { new Guid("8ba73271-9d58-4212-b477-38ce22263424"), "cde2e195-947e-4186-80f9-de43436084da", "Writer", "WRITER" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("34927024-9091-46bd-a44e-207349b1b976"), "Nothing to say", 0, new DateTime(2001, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "71d1d67a-be14-4ab0-8f1e-6712c2f7c1df", "admin@localhost.com", true, "Admin", "System", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEN8DV1OF/uWTHM6C+iTpGhJ7UMHbTaEysBJVD1wl6NKeOcVZxlEHz5eWrNAJg8OvEw==", null, false, "052bae39-18f2-4266-8030-3d0210ab083e", false, "admin" },
                    { new Guid("aa3dc70c-444f-4247-b987-b4f0c946dd36"), "Nothing to say", 0, new DateTime(2001, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "869a7e43-f214-4504-9287-08dc1a3c0368", "user@localhost.com", true, "User", "System", false, null, "USER@LOCALHOST.COM", "USER", "AQAAAAEAACcQAAAAEBr5XoK8BZw7s3Yi1swMGA6/MORNkdK3RiFg+XP0zIZY2rKOQnzJ9wpGSH09kAog7w==", null, false, "06f6cf25-0d59-4c92-976d-3cf72fccf835", false, "user" },
                    { new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), "Nothing to say", 0, new DateTime(2001, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "e2f59f11-12bb-4bf8-9c42-8cefc0327d28", "writer@localhost.com", true, "Writer", "System", false, null, "WRITER@LOCALHOST.COM", "WRITER", "AQAAAAEAACcQAAAAEDQutywY/RxzeVsEdAgLxg8lcpVEDEYgkJNS1bffxfVoYd/bQr3hjmd01DZ42wDnRw==", null, false, "e9a12e98-3d7a-4512-88e9-3c3f5994c758", false, "writer" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "ArticleContent", "DateModified", "IsPublished", "PostedOn", "ShortDescription", "Title", "UrlSlug", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("5c8aad02-50d7-4210-8225-f1e09513f0ee"), "Trong vụ án chuyến bay giải cứu, với cáo buộc nhận hối lộ 21,5 tỷ đồng, cựu Thứ trưởng Bộ Ngoại giao - ông Tô Anh Dũng - bị đề nghị mức án 12-13 năm tù. Ông Tô Anh Dũng là một trong 54 bị cáo ở vụ án chuyến bay giải cứu nói trên.\nVề trách nhiệm dân sự, bị cáo Tô Anh Dũng đã nộp 16,2 tỷ đồng khắc phục hậu quả vụ án. Viện Kiểm sát đề nghị tiếp tục truy thu bị cáo số tiền hơn 5 tỷ đồng còn lại; tiếp tục phong tỏa thửa đất đứng tên ông Dũng và tạm dừng giao dịch chuyển nhượng đối với căn hộ ở khu đô thị Tây Hồ Tây; tiếp tục phong tỏa cổ phiếu VCG của ông Dũng.\nVCG là mã cổ phiếu của Tổng Công ty cổ phần Xuất nhập khẩu và Xây dựng Việt Nam (Vinaconex). Thanh khoản tại mã cổ phiếu này thường xuyên đạt mức cao với khối lượng giao dịch trung bình gần 10,3 triệu đơn vị mỗi phiên trong vòng 1 tháng trở lại đây.\nPhiên giao dịch sáng nay (18/7), cổ phiếu VCG của Vinaconex hồi phục tăng 2,6% lên 23.300 đồng/cổ phiếu. Mức giá này của VCG đang tiệm cận vùng đỉnh của năm.\nTính so với đầu năm, VCG đã tăng mạnh 44,25% và giá cổ phiếu này đã tăng 117% nếu so với mức đáy thiết lập ngày 15/11/2022.\nTrong khi đó, trên thị trường chung phiên sáng nay, VN-Index duy trì tăng 1,86 điểm tương ứng 3,16% lên 1.174,99 điểm; HNX-Index và UPCoM-Index điều chỉnh nhẹ.\n", null, true, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Số cổ phiếu VCG của Vinaconex thuộc tài khoản ông Tô Anh Dũng tiếp tục bị đề nghị phong tỏa. Diễn biến mã VCG thời gian qua ra sao?", "Cổ phiếu trong tài khoản cựu Thứ trưởng Tô Anh Dũng lăm le tăng vượt đỉnh", "co-phieu-trong-tai-khoan-cuu-thu-truong-to-anh-dung-lam-le-tang-vuot-dinh", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 232 },
                    { new Guid("67494bcd-f5f0-48fe-a15e-02ab80ab716d"), "Ngày 16/7, công ty phụ kiện thời trang H., trụ sở tại TPHCM, đăng bài lên mạng xã hội tố hai nhân viên \"thiếu suy nghĩ, thiếu đạo đức, thiếu trách nhiệm\". Theo đó, hai sinh viên P.U. và P.N. làm digital marketing part-time tại công ty H.\nCông ty này cho biết sau vài tháng, P.U. bị đuổi việc do \"giờ giấc làm việc không nghiêm túc, thường xuyên đi trễ, về sớm; liên tục trễ deadline; trưởng bộ phận liên hệ để giải quyết công việc đều không nghe máy, ảnh hưởng tới công việc của các bạn khác\".\nCòn P.N. bị cho nghỉ việc với lý do \"kết quả làm việc yếu, không hiệu quả trong công việc, giờ công luôn tự tính cao; không liên lạc với trưởng bộ phận vì… mất điện thoại\".\nCụ thể, từ 0h15 đến 4h ngày 12/7, một nhân viên đã vào Facebook của công ty xóa khoảng 300 bài đăng với lượng tương tác nhiều nhất  mà công ty \"đã chi hàng chục tỷ đồng quảng cáo\".\nCông ty cũng tố P.N. vào Google Drive của công ty \"xóa toàn bộ thông tin, hình ảnh, dữ liệu liên quan đến các đại lý/cộng tác viên\".\nPhía công ty sau đó đã nhờ bộ phận kỹ thuật rà soát lịch sử thao tác, \"xác định đúng hai nhân sự này đã thực hiện các hành vi trên\".\nChia sẻ với phóng viên Dân trí, bà Nguyễn Thái Hà, Giám đốc điều hành John Hunt, một người có nhiều năm kinh nghiệm trong lĩnh vực nhân sự, cho rằng dù người lao động có làm sai thì doanh nghiệp không nên xử lý theo cách như vậy.\nCông ty H. đã điều hướng, kích động dư luận tấn công cá nhân và chính cách này cũng gây ra thêm rủi ro thêm cho doanh nghiệp.\nĐứng trên góc độ doanh nghiệp, bà Hà cho rằng doanh nghiệp đã có lỗ hổng về quản trị nhân sự, quản trị vận hành, quản trị hệ thống.\n", null, true, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nghỉ việc xong xóa dữ liệu, 2 nhân viên gen Z bị công ty \"bóc phốt\" trên mạng xã hội. Vậy gen Z đi sớm về muộn, \"trễ deadline\", nghỉ xong xóa dữ liệu và việc công ty phơi bày sự việc... ai văn minh?", "Gen Z đi muộn về sớm, nghỉ việc xóa dữ liệu, công ty bóc phốt: Ai văn minh?", "gen-z-di-muon-ve-som-nghi-viec-xoa-du-lieu-cong-ty-boc-phot-ai-van-minh", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 1823 },
                    { new Guid("7da36955-cd0b-4b74-bede-ffef14ad43c8"), "Công ty TNHH MTV Quản lý nợ và Khai thác tài sản Ngân hàng TMCP Công Thương Việt Nam (VietinBank AMC) mới đây thông báo xử lý tài sản bảo đảm để thu hồi nợ của Công ty cổ phần Ô tô Xuân Kiên Vinaxuki (Vinaxuki).\nKhoản nợ gốc 82,416 tỷ đồng của Vinaxuki tính đến ngày 4/7 có số lãi phát sinh lên đến 166,1 tỷ đồng. Tổng giá trị khoản nợ là 248,5 tỷ đồng.\nTài sản bảo đảm là 15 ô tô tải thương hiệu Vinaxuki đang trong kho nhà máy Vinaxuki Mê Linh (tỉnh Vĩnh Phúc). Các xe đều chưa hoàn thiện để xuất xưởng, được sản xuất từ năm 2012. Mức giá khởi điểm cũng như tình trạng hiện tại của lô xe này không được công khai. \nNăm 2012 cũng là thời điểm Vinaxuki trình làng mẫu xe 4 chỗ giá rẻ tại Triển lãm về ô tô - xe máy.\nNhững chiếc xe này là tâm huyết của ông Bùi Ngọc Huyên - Chủ tịch Vinaxuki. Tuy nhiên, ô tô \"Made in Vietnam\" đầu tiên này chỉ dừng lại ở việc xuất hiện tại triển lãm.\nThực tế, không phải lần đầu tài sản của Vinaxuki bị ngân hàng rao bán. Các ngân hàng những năm trở lại đây vẫn thường đăng tải thông tin về việc rao bán các khoản nợ hoặc tài sản của Vinaxuki.\nNăm ngoái, Vietcombank chi nhánh Thăng Long rao bán đấu giá hệ thống máy móc, thiết bị tại nhà máy sản xuất ô tô số 1 thuộc chi nhánh Vinaxuki tại huyện Mê Linh, Hà Nội.\nGiá khởi điểm cho khối tài sản đảm bảo này là 33,128 tỷ đồng. Đây là tài sản đã được tòa án tuyên thuộc quyền sở hữu của ngân hàng, do đó phiên đấu giá diễn ra tại Chi cục Thi hành án dân sự huyện Mê Linh.\n", null, true, new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Khoản nợ gốc 82,4 tỷ đồng của Vinaxuki hiện đã lên tới gần 250 tỷ đồng. Tài sản bảo đảm là 15 ô tô Vinaxuki sản xuất từ năm 2012, chưa hoàn thiện trong kho, đang được VietinBank AMC rao bán.", "15 ô tô Vinaxuki sản xuất từ năm 2012 được rao bán", "15-o-to-vinaxuki-san-xuat-tu-nam-2012-duoc-rao-ban", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 232 },
                    { new Guid("85147f76-c8b4-404c-a7de-73fc331a1cf9"), "Thủ khoa toàn quốc năm 2021 Trần Ngọc Anh học quản lý chuỗi cung ứng ở Trường Đại học Ngoại thương.\nDù là thủ khoa nhưng Trần Ngọc Anh không sử dụng kết quả này để xét tuyển đại học bởi trước đó nữ sinh đã trúng tuyển vào Trường Đại học Ngoại thương thông qua xét học bạ và điểm IELTS 7,5.\nHiện tại, Ngọc Anh đang theo học ngành logistics và quản lý chuỗi cung ứng theo định hướng nghề nghiệp quốc tế.\nTrong kỳ thi tốt nghiệp THPT năm 2021, Trần Ngọc Anh (học sinh trường THPT chuyên Hà Nội - Amsterdam) đạt 9,2 điểm môn toán; 9,25 điểm môn ngữ văn; 9,5 điểm ở hai môn lịch sử và địa lý; 10 điểm ở hai môn tiếng Anh và giáo dục công dân (GDCD). Nữ sinh đã trở thành thủ khoa toàn quốc với tổng điểm 57,45.\nBí kíp của Ngọc Anh là học cách tư duy thông minh, giúp đạt kết quả tốt dù không mất quá nhiều thời gian ôn luyện. Bên cạnh đó, duy trì cảm hứng học tập cũng là một yếu tố quan trọng giúp Ngọc Anh học đều tất cả các môn.\nThủ khoa toàn quốc năm 2022 Phạm Văn Linh chọn ngành khoa học máy tính ở Trường Đại học Kinh tế Quốc dân\nHiện tại, Phạm Văn Linh đang là sinh viên năm 2 của trường Đại học Kinh tế Quốc dân. Với mong muốn tìm hiểu kiến thức về máy tính và trở thành lập trình viên trong tương lai, nam sinh đã chọn học ngành khoa học máy tính.\nTrước đó, nam sinh Phạm Văn Linh (học sinh lớp 12M, trường THPT Yên Khánh A, Ninh Bình) đạt tổng điểm ấn tượng 56,85 và trở thành thủ khoa toàn quốc của kỳ thi tốt nghiệp THPT 2022. Cụ thể, Linh đạt 9,2 điểm môn toán, 9,25 điểm ở hai môn ngữ văn và địa lý, 10 điểm môn lịch sử và 9,75 điểm môn GDCD.\nThủ khoa năm 2022 cho hay, bản thân chưa bao giờ đi học thêm ngoài mà chủ yếu là tự học, tự ôn tập. Phạm Văn Linh là tấm gương sáng về tinh thần tự học, vượt khó vươn lên. Hoàn cảnh gia đình Linh khó khăn, bố mất còn mẹ là công nhân tần tảo nuôi hai anh em ăn học.", null, true, new DateTime(2023, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Các thủ khoa tốt nghiệp THPT toàn quốc được thoải mái lựa chọn ngành học đại học theo sở trường. Vậy các bạn đã chọn ngành học gì, định hướng tương lai ra sao?", "Thủ khoa tốt nghiệp THPT toàn quốc 3 năm qua chọn học ngành gì?", "thu-khoa-tot-nghiep-thpt-toan-quoc-3-nam-qua-chon-hoc-nganh-gi", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 1263 },
                    { new Guid("89dc747b-f9a4-4f74-b74e-fe6a2e912cb2"), "Cổ phiếu MWG của Thế Giới Di Động là mã có ảnh hưởng tích cực nhất đối với VN-Index trong sáng nay (21/7). Mã này tăng 4,5% lên 51.300 đồng và cũng là mã tăng mạnh nhất trong rổ VN30. Thanh khoản trong phiên sáng nay tại MWG cũng tăng vọt so với các phiên trước đó.\nVới mức giá hiện tại, MWG đã đạt mức đỉnh giá kể từ đầu năm và tăng hơn 30% so với mức đóng cửa thấp nhất thiết lập 3 tháng trước.\nGiá cổ phiếu MWG hồi phục mạnh trong bối cảnh ngành bán lẻ đang gặp nhiều khó khăn. Theo phản ánh của báo chí, do sức mua xuống thấp nên các doanh nghiệp đã phải dùng mọi biện pháp để kích cầu và cạnh tranh.\nTại Thế giới di động, đại gia gốc Nam Định, ông Nguyễn Đức Tài - Chủ tịch công ty - đang sở hữu hơn 35,1 triệu cổ phiếu MWG tương ứng 2,4% vốn điều lệ.\nGiá cổ phiếu tăng mạnh cũng kéo theo tài sản của ông Nguyễn Đức Tài tăng theo tương ứng. Chỉ tính riêng khối lượng cổ phiếu MWG mà cá nhân ông Tài sở hữu, giá trị tài sản trên sàn của vị đại gia khoảng hơn 1.800 tỷ đồng.\nCổ phiếu bán lẻ nhìn chung có diễn biến khả quan trong phiên sáng nay. Bên cạnh MWG thì DGW cũng tăng 3,1%; PET tăng 1,9%; ABS tăng 1,7%; SBV tăng 1%; AST và FRT tăng nhẹ.\nTrong khi MWG diễn biến tích cực thì phân nửa rổ VN30 giảm. Một số mã có mức điều chỉnh khá mạnh (trên 1%) là VJC, BCM và POW. VCB giảm 0,9%; HDB giảm 0,6%; SAB, VIC, FPT, CTG… giảm giá cũng phần nào ảnh hưởng đến chỉ số chung.\nNhóm cổ phiếu ngành dịch vụ tài chính duy trì tăng tốt với việc VIX tăng 3%; CTS tăng 1,8%; VND tăng 1,7%; APG tăng 1,3%. Một số mã khác tăng nhẹ như FTS, SSI, TVS, AGR, BCG.\n", null, true, new DateTime(2023, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trong khi các doanh nghiệp bán lẻ đang gặp khó vì sức mua xuống thấp, phải liên tục giảm giá để kích cầu thì cổ phiếu các công ty này lại tăng. MWG tăng mạnh sáng nay.", "Tài sản đại gia Nam Định tăng mạnh giữa cuộc chiến \"sale xuống đáy\"", "tai-san-dai-gia-nam-dinh-tang-manh-giua-cuoc-chien-sale-xuong-day", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 1684 },
                    { new Guid("b93b15ac-a799-4de4-801a-8d1a06354d0f"), "Thủ tướng Chính phủ vừa có quyết định về việc điều động, bổ nhiệm ông Đặng Hoàng An, Thứ trưởng Bộ Công Thương, giữ chức Chủ tịch Hội đồng thành viên Tập đoàn Điện lực Việt Nam (EVN). Quyết định bổ nhiệm có hiệu lực kể từ ngày 19/7.\nChủ tịch EVN trước đó là ông Dương Quang Thành. Ông Thành có quyết định nghỉ hưu từ ngày 1/5.\nÔng Đặng Hoàng An sinh ngày 16/10/1965, quê quán Hiệp Hòa, Bắc Giang. Ông An được giới thiệu tốt nghiệp Đại học chuyên ngành Năng lượng điện tại CH Séc và tốt nghiệp Thạc sĩ Quản lý hệ thống điện và Thạc sĩ Quản trị kinh doanh tại Học viện Công nghệ châu Á tại Thái Lan, thông thạo các ngoại ngữ tiếng Anh, tiếng Tiệp Khắc, trình độ lý luận chính trị cao cấp.\nTrước khi được bổ nhiệm Thứ trưởng Bộ Công Thương, ông Đặng Hoàng An đã trải qua nhiều vị trí công tác và đảm nhận các chức trách lãnh đạo quản lý trong ngành điện.\nCụ thể, ông từng làm Phó giám đốc Trung tâm Điều độ Hệ thống điện Quốc gia từ năm 1993 đến 2004, Trưởng Ban Kỹ thuật Lưới điện EVN từ 2004 đến 2006, Phó giám đốc Công ty Truyền tải điện 1 từ 2006 đến 2007, Trưởng Ban Kế hoạch EVN từ 2007 đến 2008, Phó tổng giám đốc EVN từ 2008 đến 2015 và Tổng giám đốc EVN từ tháng 7/2015 đến 5/2018.\nÔng Đặng Hoàng An quay trở lại EVN đúng vào thời điểm tập đoàn này đang phải đối mặt với nhiều khó khăn liên quan đến dòng tiền và đảm bảo cung cấp điện.\nTheo báo cáo tài chính hợp nhất đã kiểm toán năm 2022, doanh thu hợp nhất của tập đoàn năm qua đạt 463.000 tỷ đồng, tăng 8% so với cùng kỳ năm 2021. Trong đó, doanh thu từ bán điện chiếm tới 98%, đạt trên 456.000 tỷ đồng.\nTuy nhiên, do giá vốn hàng bán tăng nhanh hơn doanh thu nên lợi nhuận gộp của EVN giảm mạnh, từ 38.264 tỷ đồng còn 10.580 tỷ đồng. Số liệu này, theo lãnh đạo EVN từng cho biết do giá bán điện thấp hơn giá mua vào.\nTrong kỳ, doanh thu hoạt động tài chính của EVN giảm mạnh, trong khi các chi phí khác đều tăng. Kết quả, EVN ghi nhận lỗ 19.515 tỷ đồng từ hoạt động kinh doanh và lỗ sau thuế là 20.747 tỷ đồng. Riêng công ty mẹ EVN lỗ sau thuế 22.256 tỷ đồng.\n", null, true, new DateTime(2023, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thủ tướng vừa có quyết định điều động, bổ nhiệm ông Đặng Hoàng An, Thứ trưởng Bộ Công Thương, giữ chức Chủ tịch Hội đồng thành viên Tập đoàn Điện lực Việt Nam", "EVN có chủ tịch mới, là một Thứ trưởng Bộ Công Thương\n", "evn-co-chu-tich-moi-la-mot-thu-truong-bo-cong-thuong", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 4278 },
                    { new Guid("c04c3955-db31-4757-9292-cf0015ae578d"), "Chia sẻ với báo giới, Carlos Alcaraz cho biết: \"Tôi không nghĩ có thời đại mới nào cả, khi Djokovic và Nadal còn thi đấu. Tôi giành chiến thắng vì bản thân, vì đội ngũ, không phải để bắt đầu kỷ nguyên mới. Chuyện này chỉ đáng bàn trong vài năm nữa, khi Nadal và Djokovic giải nghệ.\nViệc Djokovic nói rằng anh ấy chưa từng đấu với ai như tôi là một lời khen giúp tôi thêm động lực cải thiện bản thân. Tôi đã sẵn sàng cả thể chất và tinh thần để chơi những trận kịch chiến với các huyền thoại như trận chung kết Wimbledon vừa qua\".\nTay vợt người Tây Ban Nha tiết lộ thành công của anh hiện tại nhờ việc chơi cờ vua từ nhỏ: \"Trước mỗi trận đấu, tôi thường ngủ trưa rồi dậy đánh cờ vua. Cờ vua cũng như quần vợt, chỉ cần một khoảnh khắc mất tập trung, bạn sẽ phải trả giá. Cờ vua giúp tôi duy trì sự tập trung mọi lúc, quan sát kỹ lưỡng và dự đoán đối thủ sẽ làm gì tiếp theo\".\nỞ tuổi 20, Carlos Alcaraz đã giành 2 Grand Slam là US Open 2022 và Wimbledon 2023. Ngôi sao người Tây Ban Nha đã sở hữu 12 chức vô địch và có tuần thứ 29 giữ ngôi số một thế giới.\nSau Wimbledon 2023, Alcaraz sẽ có khoảng thời gian dài nghỉ ngơi trước khi bước vào các giải đấu lớn ở Bắc Mỹ gồm Roger Cup (5/8 đến 13/8), Cincinnati Masters (14/8 đến 22/8) và đặc biệt là US Open 2023 (28/8 đến 10/9).\n", null, true, new DateTime(2023, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carlos Alcaraz cho rằng bản thân anh đánh bại Djokovic ở chung kết Wimbledon không đồng nghĩa với việc đàn anh người Serbia đã hết thời.", "Alcaraz: \"Chưa có thời đại mới nếu Nadal, Djokovic còn thi đấu\"", "alcaraz-chua-co-thoi-dai-moi-neu-nadal-djokovic-con-thi-dau", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 2316 },
                    { new Guid("c4f8f808-4a25-4704-aedd-b8a0e03a9773"), "Trong những ngày qua, nhiều tờ báo lớn trên thế giới rộ lên thông tin FIFA sẽ chia trực tiếp tiền thưởng ở World Cup nữ 2023 tới các cầu thủ. Theo đó, mỗi người sẽ nhận ít nhất 30.000 USD (khoảng 710 triệu đồng) khi tham dự World Cup.\nTuy nhiên, chia sẻ trước ngày khai mạc World Cup, Chủ tịch FIFA, Gianni Infantino đã đính chính thông tin này. Theo đó, không có chuyện FIFA chia tiền thưởng cho từng cầu thủ. Thay vào đó, số tiền này vẫn được chuyển về các Liên đoàn bóng đá.\nNgười đứng đầu FIFA cho biết: \"Chúng tôi là hiệp hội của các hiệp hội bóng đá. Vì vậy, bất kỳ khoản thanh toán nào cũng phải thông qua các Liên đoàn bóng đá. Sau đó, các Liên đoàn sẽ chia tiền thưởng cho cầu thủ.\nChúng tôi vẫn giữ liên lạc với các Liên đoàn bóng đá. Có nhiều tình huống khác nhau, ở từng khu vực trên thế giới nên việc chia tiền cho từng cầu thủ là không khả thi. Chúng tôi cũng đòi hỏi có thỏa thuận đặc biệt giữa Liên đoàn và các cầu thủ về vấn đề tiền thưởng\".\nTổng số tiền FIFA chi ra ở World Cup nữ 2023 là 150 triệu USD. Trong đó, họ chi 110 triệu USD tiền thưởng cho các đội bóng tham dự, 31 triệu USD cho quỹ chuẩn bị giải đấu, 11 triệu USD cho các CLB có thành viên tham dự.\nSố tiền thưởng cho các đội bóng tham dự World Cup 2023 (110 triệu USD) tăng hơn 3 lần so với giải đấu cách đây 4 năm (30 triệu USD) và tăng gấp 10 lần so với World Cup 2015. Điều đó cho thấy nỗ lực của FIFA trong công cuộc thúc đẩy bóng đá nữ trên toàn thế giới.\nNói về thông tin này, người đứng đầu FIFA vui mừng cho biết: \"Ở thời điểm này, tôi chỉ tập trung vào những điều tích cực, hạnh phúc và niềm vui. Tôi đã nghe khá nhiều điều tích cực về vấn đề tiền thưởng trong thời gian qua. Nếu ai đó chưa hài lòng, tôi xin lỗi\".\nCó chi tiết đáng chú ý, trước đây, FIFA đã gộp tiền bán bản quyền truyền hình World Cup nam và nữ. Điều đó có nghĩa rằng, giải World Cup nữ được phát miễn phí. Tuy nhiên, kể từ năm 2023, lần đầu tiên FIFA đã thương mại hóa, bán bản quyền phát sóng giải World Cup nữ riêng. Nhờ đó, FIFA có thể tăng tiền thưởng cho các đội tuyển nữ tham dự giải đấu.\nTheo ông Infantino, mức thu nhập bình quân của một cầu thủ bóng đá nữ toàn cầu là 14.000 USD mỗi năm. Do đó, FIFA quyết định trả hai năm thu nhập bình quân cho mỗi cầu thủ tham dự World Cup 2023 để họ có thể yên tâm cống hiến và tập trung vươn tới đỉnh cao.\n", null, true, new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chủ tịch FIFA, Gianni Infantino xác nhận vẫn chia tiền thưởng về liên đoàn, thay vì trả trực tiếp cho cầu thủ như nhiều nguồn tin trước đó.", "FIFA thông báo bất ngờ về tiền thưởng các đội tuyển nữ ở World Cup", "fifa-thong-bao-bat-ngo-ve-tien-thuong-cac-doi-tuyen-nu-o-world-cup", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 4212 },
                    { new Guid("c577130a-1305-4374-9d20-05bd0ae0d8f9"), "Trao đổi với phóng viên Dân trí, lãnh đạo một số doanh nghiệp xăng dầu cho biết thời gian qua, giá xăng thành phẩm bình quân trên thị trường Singapore có xu hướng tăng so với kỳ trước. Mức tăng tương đối mạnh.\nDựa trên diễn biến giá thế giới, các doanh nghiệp dự báo trong kỳ điều hành ngày 21/7, xăng E5 RON 92 và RON 95 trong nước có thể tăng 800-1.000 đồng/lít, dầu diesel có thể tăng 500-600 đồng/lít. Nếu liên Bộ Công Thương, Bộ Tài chính chi quỹ bình ổn, giá xăng dầu có thể tăng ít hơn. \nTại kỳ điều chỉnh gần nhất ngày 11/7, xăng E5 RON 92 giảm 60 đồng/lít, xuống 20.410 đồng/lít; xăng RON 95 tăng 70 đồng/lít, lên 21.490 đồng/lít. Trong khi đó, giá dầu diesel tăng 450 đồng/lít lên 18.610 đồng/lít.\nMới đây, Phó Thủ tướng Trần Hồng Hà đã ký quyết định phê duyệt quy hoạch hạ tầng dự trữ, cung ứng xăng dầu, khí đốt quốc gia thời kỳ 2021-2030, tầm nhìn đến năm 2050.\nCụ thể, với hạ tầng xăng dầu, dự trữ dầu thô và sản phẩm chế biến xăng dầu đáp ứng tối thiểu 20-25 ngày nhập ròng, xăng dầu thương mại đáp ứng 30-35 ngày, còn hạ tầng dự trữ quốc gia là 15-30 ngày nhập khẩu ròng.\nVới LPG, hạ tầng dự trữ đạt sức chứa tới 800.000 tấn giai đoạn 2021-2030 và tới 900.000 tấn giai đoạn sau năm 2030.\nDo vậy, Việt Nam sẽ xây mới 500.000m3 kho chứa xăng dầu đến 2030 phục vụ dự trữ quốc gia. Kho dự trữ dầu thô sẽ được xây mới 1-2 kho tại các khu vực gần nhà máy lọc dầu (Dung Quất, Nghi Sơn, Long Sơn), với tổng công suất 1-2 triệu tấn dầu thô.\nVới hạ tầng dự trữ thương mại, sẽ tiếp tục khai thác 89 kho hiện nay và mở rộng, nâng công suất các kho thương mại lên khoảng 1,4 triệu m3. Cùng đó, 59 kho xăng dầu thương mại sẽ được xây mới tại các địa phương, tổng công suất khoảng 5,1 triệu m3.\nHệ thống đường ống xăng dầu hiện có với 580,9km cũng sẽ được đầu tư nâng cấp sau đó xây mới tuyến ống dẫn nhiên liệu bay từ kho đầu nguồn tại TP.HCM, Đồng Nai, Bà Rịa - Vũng Tàu về kho sân bay Long Thành. \n", null, true, new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giá xăng dầu ngày 21/7 được dự báo tăng mạnh theo xu hướng thế giới. Nếu cơ quan quản lý không tác động đến quỹ bình ổn, giá mặt hàng nhiên liệu có thể tăng 800-1.000 đồng/lít.", "Giá xăng sắp tăng mạnh?", "gia-xang-sap-tang-manh", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 5245 },
                    { new Guid("c9013af1-01a8-4720-bdf0-b6b155958762"), "Ngày 21/7, Tổng Bí thư Nguyễn Phú Trọng đã chủ trì cuộc họp Bộ Chính trị, Ban Bí thư để cho ý kiến về Báo cáo tình hình kinh tế - xã hội 6 tháng đầu năm, nhiệm vụ, giải pháp 6 tháng cuối năm 2023.\nNhấn mạnh một số nội dung khi đề cập nhiệm vụ, giải pháp cho 6 tháng cuối năm, Bộ Chính trị yêu cầu cần khẩn trương, quyết liệt tập trung rà soát, hoàn thiện cơ chế chính sách, pháp luật. Bên cạnh đó, đẩy mạnh phân cấp, phân quyền; tiếp tục rà soát, sắp xếp bộ máy tinh gọn, hiệu lực, hiệu quả.\nBộ Chính trị quán triệt nhất quán mục tiêu giữ vững ổn định kinh tế vĩ mô, kiểm soát lạm phát, thúc đẩy tăng trưởng và bảo đảm các cân đối lớn của nền kinh tế.\nTrong điều hành, Bộ Chính trị lưu ý thực hiện chính sách tài khóa có trọng tâm, trọng điểm, tập trung hỗ trợ doanh nghiệp, người dân để giảm áp lực chi phí, thúc đẩy sản xuất.\nNgoài ra, Bộ Chính trị cho rằng chính sách tiền tệ cần chủ động, linh hoạt, tăng khả năng tiếp cận vốn, tạo động lực tăng trưởng.\nBộ Chính trị cũng yêu cầu thúc đẩy mạnh mẽ công tác giải ngân vốn đầu tư công; có giải pháp hiệu quả bảo đảm các thị trường trái phiếu doanh nghiệp, bất động sản, tín dụng ngân hàng, chứng khoán, khoa học công nghệ hoạt động an toàn, lành mạnh, bền vững.\nBên cạnh đó, nguồn cung xăng dầu, nguồn điện cho sản xuất, tiêu dùng phải được đảm bảo, theo yêu cầu của Bộ Chính trị.\nBộ Chính trị cũng lưu ý tập trung xử lý nhanh, hiệu quả các vướng mắc về hoàn thuế giá trị gia tăng, thuốc, vật tư y tế, quy định về kinh doanh xăng dầu, phòng cháy chữa cháy; triển khai quy hoạch điện VIII.\nTrong định hướng phát triển, Bộ Chính trị lưu ý tập trung vào các động lực tăng trưởng mới của nền kinh tế, tranh thủ tối đa nguồn lực hỗ trợ từ bên ngoài để thúc đẩy đổi mới sáng tạo, phát triển kinh tế số, chuyển đổi số; hoàn thiện chiến lược, chính sách phát triển năng lượng mới, chuyển đổi xanh…\n", null, true, new DateTime(2023, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bên cạnh nhiệm vụ phát triển kinh tế, xã hội, Bộ Chính trị yêu cầu đẩy nhanh tiến độ điều tra, xử lý dứt điểm các vụ án, vụ việc do Ban Chỉ đạo Trung ương về PCTN, tiêu cực chỉ đạo, theo dõi.", "Bộ Chính trị yêu cầu sớm điều tra, xử lý dứt điểm các đại án tham nhũng", "bo-chinh-tri-yeu-cau-som-dieu-tra-xu-ly-dut-diem-cac-dai-an-tham-nhung", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 8216 },
                    { new Guid("ece58bc2-f93a-4ef4-866f-6d7c453535ec"), "Tập đoàn China Evergrande vừa công bố khoản lỗ hơn 81 tỷ USD (khoảng 1,9 triệu tỷ đồng) trong 2 năm qua. Như vậy, sau một thời gian dài trì hoãn, cuối cùng công ty bất động sản nợ nhiều nhất thế giới cũng công bố báo cáo kết quả kinh doanh.\nĐộng thái này được cho là nỗ lực nhằm đưa cổ phiếu được giao dịch trở lại và hoàn thành một trong những vụ tái cấu trúc nợ lớn nhất cả nước.\nPhía Evergrande báo cáo khoản lỗ lớn trên một phần nhiều là bởi khoản chi cho các cổ đông năm 2022 lên tới gần 106 tỷ nhân dân tệ, năm trước đó cũng thua lỗ thêm 476 tỷ nhân dân tệ.\nKết quả này cho thấy Evergrande đã chật vật như thế nào trong cuộc khủng hoảng của thị trường bất động sản Trung Quốc. Sau khi Chính phủ nước này siết chặt hoạt động cho vay đối với doanh nghiệp bất động sản và người mua nhà, doanh số bán nhà lao dốc chóng mặt.\nKết quả này cũng đánh dấu chuỗi 2 năm thua lỗ liên tiếp đầu tiên của Evergrande kể từ khi niêm yết vào năm 2009.\nDoanh thu của Evergrande giảm một nửa trong năm 2021, xuống còn 250 tỷ nhân dân tệ. Doanh thu của công ty năm 2022 cũng tiếp tục giảm mạnh còn 230 tỷ nhân dân tệ, thấp hơn nhiều so với dự đoán của các chuyên gia phân tích trước đó.\nCùng với sự xuất hiện của thua lỗ, mức nợ của Evergrande tăng chóng mặt. Khối nợ của tập đoàn đã tăng lên mức 2.580 tỷ nhân dân tệ vào cuối năm 2021. Đến cuối năm 2022, số nợ là 2.440 tỷ nhân dân tệ.\nTheo nhận định của các chuyên gia, Evergande có thể tiến gần hơn tới trạng thái được giao dịch cổ phiếu trở lại sau khi công bố kết quả kinh doanh. Lượng tiền mặt của công ty ở thời điểm cuối năm ngoái chỉ còn 4.300 tỷ nhân dân tệ, trong khi số nợ ngắn hạn là khoảng 587 tỷ nhân dân tệ. Do đó, các nhà phân tích của Bloomberg cho rằng có khả năng kế hoạch tái cơ cấu nợ của Evergrande sẽ được phê chuẩn.\n", null, true, new DateTime(2023, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Evergrande đã trở thành một ví dụ điển hình khi nhắc đến cuộc khủng hoảng bất động sản ở Trung Quốc. Từ năm 2009, Evergrande chưa từng thua lỗ nhưng riêng 2 năm vừa qua, tập đoàn này lỗ tới 81 tỷ USD.", "\"Chúa chổm\" Evergrande lỗ 81 tỷ USD trong 2 năm", "chua-chom-evergrande-lo-81-ty-usd-trong-2-nam", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 2088 },
                    { new Guid("f142472e-9c7a-4aef-a4f5-b671887558a6"), "Khu đô thị Linh Đàm thuộc phường Hoàng Liệt, quận Hoàng Mai - vị trí cửa ngõ phía Nam Thủ đô, đầu mối giao thông quan trọng của thành phố.\nLinh Đàm từng được coi là quy hoạch khu đô thị kiểu mẫu, thuộc loại đẹp nhất và lớn nhất Hà Nội. Tuy nhiên, trong vòng xoáy của đô thị hóa, khu đô thị này đã \"mọc\" lên hàng chục tòa chung cư san sát, phá vỡ quy hoạch ban đầu. Điển hình như 12 tòa HH trong bán đảo Linh Đàm có tới 40.000 dân, con số này gần bằng 2 phường bình thường của TP Hà Nội.\nDân số cơ học liên tục tăng, quy hoạch bị phá vỡ, hạ tầng xã hội không theo kịp dẫn tới tình trạng thiếu trường học, giao thông ùn tắc vào giờ cao điểm…\nHiện nay, vấn đề giao thông, trường học đang được TP Hà Nội và các cơ quan chức năng đặc biệt quan tâm giải quyết tại khu đô thị này. \nTheo quy hoạch phân khu đô thị H2-3, khu đô thị Linh Đàm có một số tuyến đường quy hoạch kết nối với đường 70, QL1A.\nĐơn cử như tuyến đường bên hông chung cư HH Linh Đàm đến Bằng B. Tuyến đường quy hoạch này đi qua khu vực sân vận động Hoàng Mai, rộng 17-22m.\nTuyến đường này cũng đi qua phố Linh Đường, khoảng giữa của trường THCS Linh Đàm - dự án Bệnh viện Xây dựng và nối vào đường quy hoạch qua khu dân cư Bằng B.\nTheo quy hoạch, tuyến phố Linh Đường cũng sẽ kết nối với đường Phan Trọng Tuệ (đường 70). Tuyến đường này rộng khoảng 30m, đi qua dự án Melody Residences và sông Tô Lịch.\n", null, true, new DateTime(2023, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Áp lực lên hạ tầng xã hội do dân số cơ học tăng nhanh, hậu quả từ việc phá vỡ quy hoạch là vấn đề nhức nhối tại Khu đô thị Linh Đàm (Hà Nội) thời gian qua.", "Các tuyến đường kết nối Linh Đàm - dự án nổi tiếng \"băm nát\" quy hoạch", "cac-tuyen-duong-ket-noi-linh-dam-du-an-noi-tieng-bam-nat-quy-hoach", new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6"), 1684 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("55ab95a7-8830-4eb9-966a-2196880296b4"), new Guid("34927024-9091-46bd-a44e-207349b1b976") },
                    { new Guid("481d5ff4-d4d8-46c0-b356-898097c2c3c9"), new Guid("aa3dc70c-444f-4247-b987-b4f0c946dd36") },
                    { new Guid("8ba73271-9d58-4212-b477-38ce22263424"), new Guid("d780e202-35b3-4604-bb86-ea6b9a416bb6") }
                });

            migrationBuilder.InsertData(
                table: "ArticleCategories",
                columns: new[] { "ArticleId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("5c8aad02-50d7-4210-8225-f1e09513f0ee"), new Guid("8d29ed4f-5f51-452d-9ca0-1a90f6be2213") },
                    { new Guid("67494bcd-f5f0-48fe-a15e-02ab80ab716d"), new Guid("bbd033f7-c6d9-4029-8217-1ba6aa59b724") },
                    { new Guid("7da36955-cd0b-4b74-bede-ffef14ad43c8"), new Guid("c89df401-4192-47e5-8608-bacd9bb4d0b3") },
                    { new Guid("85147f76-c8b4-404c-a7de-73fc331a1cf9"), new Guid("867cc1c4-ecba-403d-84d5-9dee111567a7") },
                    { new Guid("89dc747b-f9a4-4f74-b74e-fe6a2e912cb2"), new Guid("7fef1bb3-0bac-4be9-ab94-c8c817cf1a3d") },
                    { new Guid("b93b15ac-a799-4de4-801a-8d1a06354d0f"), new Guid("7fef1bb3-0bac-4be9-ab94-c8c817cf1a3d") },
                    { new Guid("c04c3955-db31-4757-9292-cf0015ae578d"), new Guid("12428f09-81f2-49d7-985f-6bc0a0da015a") },
                    { new Guid("c4f8f808-4a25-4704-aedd-b8a0e03a9773"), new Guid("a50e1f05-b24a-4555-a043-0fa3b8e01ce4") },
                    { new Guid("c577130a-1305-4374-9d20-05bd0ae0d8f9"), new Guid("c89df401-4192-47e5-8608-bacd9bb4d0b3") },
                    { new Guid("c9013af1-01a8-4720-bdf0-b6b155958762"), new Guid("7593f61e-2eba-484d-8904-ddbd5ea07449") },
                    { new Guid("c9013af1-01a8-4720-bdf0-b6b155958762"), new Guid("867cc1c4-ecba-403d-84d5-9dee111567a7") },
                    { new Guid("ece58bc2-f93a-4ef4-866f-6d7c453535ec"), new Guid("5ab04e34-3529-4984-bb90-f707691c5542") },
                    { new Guid("ece58bc2-f93a-4ef4-866f-6d7c453535ec"), new Guid("7593f61e-2eba-484d-8904-ddbd5ea07449") },
                    { new Guid("f142472e-9c7a-4aef-a4f5-b671887558a6"), new Guid("bbd033f7-c6d9-4029-8217-1ba6aa59b724") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ArticleId", "CommentHeader", "CommentText", "CommentTime", "UserId" },
                values: new object[] { new Guid("db106c9a-0a4d-4ff1-9e90-9e6a3ad20ff9"), new Guid("c04c3955-db31-4757-9292-cf0015ae578d"), "Carlos Alcaraz lên ngôi ở Wimbledon 2023 đầy thuyết phục", "12 chức vô địch, tuần thứ 29 giữ ngôi số một thế giới, ghê thật! Mãi giữ vững phong độ anh nhé", new DateTime(2023, 7, 22, 13, 31, 22, 113, DateTimeKind.Local).AddTicks(6700), new Guid("aa3dc70c-444f-4247-b987-b4f0c946dd36") });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategories_CategoryId",
                table: "ArticleCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategories");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
