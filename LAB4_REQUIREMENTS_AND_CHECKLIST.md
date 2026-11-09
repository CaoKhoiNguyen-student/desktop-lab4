# BÁO CÁO YÊU CẦU BÀI TẬP VÀ CHECKLIST THỰC HIỆN - LAB 4: KẾT NỐI VÀ TRUY VẤN DỮ LIỆU
**Môn học:** Cơ sở dữ liệu / Lập trình Windows Forms  
**Chủ đề:** CHỦ ĐỀ 4. KẾT NỐI VÀ TRUY VẤN DỮ LIỆU (ADO.NET)  
**Database sử dụng:** `RestaurantManagement` trên SQL Server  

---

## I. MỤC TIÊU VÀ KIẾN THỨC CẦN NẮM
1. **Kiến thức cốt lõi:**
   - Cấu trúc chuỗi kết nối (`ConnectionString`) và ý nghĩa các tham số (`server`, `database`, `Integrated Security`, `TrustServerCertificate`...).
   - Đối tượng kết nối `SqlConnection` (Open, Close, Dispose).
   - Đối tượng thực thi lệnh `SqlCommand` với các phương thức:
     - `ExecuteReader()`: Dùng cho truy vấn SELECT trả về nhiều dòng, đọc dữ liệu một chiều qua `SqlDataReader`.
     - `ExecuteScalar()`: Dùng cho truy vấn SELECT trả về một giá trị đơn lẻ (VD: `COUNT`, `SUM`, lấy tên theo ID).
     - `ExecuteNonQuery()`: Dùng cho các lệnh INSERT, UPDATE, DELETE (trả về số dòng bị tác động `numOfRowsAffected`).
   - Đối tượng ngắt kết nối `SqlDataAdapter`, `DataTable`, `SqlCommandBuilder` (phương thức `Fill`, `Update`).
   - Tương tác giao diện Windows Forms: ListView, DataGridView, ContextMenuStrip, DateTimePicker, ComboBox, ListBox.

---

## II. CẤU TRÚC CƠ SỞ DỮ LIỆU (RESTAURANTMANAGEMENT)
1. **`Category`** (Nhóm món ăn):
   - `ID` (int, Identity, PK): Mã nhóm.
   - `Name` (nvarchar(1000)): Tên nhóm món ăn.
   - `Type` (int): 0 = Thức uống, 1 = Đồ ăn.
2. **`Food`** (Món ăn):
   - `ID` (int, Identity, PK): Mã món ăn.
   - `Name` (nvarchar(1000)): Tên món.
   - `Unit` (nvarchar(100)): Đơn vị tính (Dĩa, Tô, Lon, Chai...).
   - `FoodCategoryID` (int, FK -> Category.ID): Mã nhóm món ăn.
   - `Price` (int): Đơn giá.
   - `Notes` (nvarchar(3000)): Ghi chú.
3. **`Table`** (Bàn ăn):
   - `ID` (int, Identity, PK): Mã bàn.
   - `Name` (nvarchar(1000)): Tên bàn.
   - `Status` (int): Trạng thái bàn (0: Trống, 1: Có người / Phục vụ).
   - `Capacity` (int): Số chỗ ngồi.
4. **`Bills`** (Hóa đơn):
   - `ID` (int, Identity, PK): Mã hóa đơn.
   - `Name` (nvarchar(1000)): Tên hóa đơn.
   - `TableID` (int, FK -> Table.ID): Mã bàn.
   - `Amount` (int): Tổng tiền chưa giảm giá / tiền thanh toán trước thuế & chiết khấu.
   - `Discount` (float): Tỉ lệ giảm giá (vd: 0.05 = 5%).
   - `Tax` (float): Tỉ lệ thuế (vd: 0.1 = 10%).
   - `Status` (bit): Trạng thái hóa đơn (0: Chưa thanh toán, 1: Đã thanh toán).
   - `CheckoutDate` (smalldatetime): Ngày giờ thanh toán.
   - `Account` (nvarchar(100), FK -> Account.AccountName): Tài khoản nhân viên lập hóa đơn.
5. **`BillDetails`** (Chi tiết hóa đơn):
   - `ID` (int, Identity, PK): Mã chi tiết.
   - `InvoiceID` (int, FK -> Bills.ID): Mã hóa đơn.
   - `FoodID` (int, FK -> Food.ID): Mã món ăn.
   - `Quantity` (int): Số lượng mua.
6. **`Account`** (Tài khoản người dùng):
   - `AccountName` (nvarchar(100), PK): Tên đăng nhập.
   - `Password` (nvarchar(200)): Mật khẩu.
   - `FullName` (nvarchar(1000)): Họ và tên.
   - `Email` (nvarchar(1000)): Email.
   - `Tell` (nvarchar(200)): Số điện thoại.
   - `DateCreated` (smalldatetime): Ngày tạo tài khoản.
7. **`Role`** (Vai trò / Nhóm quyền):
   - `ID` (int, PK): Mã vai trò (1: Administrator, 2: Kế toán, 3: Nhân viên thanh toán, 4: Nhân viên phục vụ).
   - `RoleName` (nvarchar(1000)): Tên vai trò.
   - `Path` (nvarchar(3000)): Đường dẫn.
   - `Notes` (nvarchar(3000)): Ghi chú.
8. **`RoleAccount`** (Phân quyền tài khoản):
   - `RoleID` (int, PK, FK -> Role.ID): Mã vai trò.
   - `AccountName` (nvarchar(100), PK, FK -> Account.AccountName): Tên tài khoản.
   - `Actived` (bit): Trạng thái kích hoạt (1: Đang kích hoạt, 0: Ngưng kích hoạt).
   - `Notes` (nvarchar(3000)): Ghi chú.

---

## III. CHI TIẾT YÊU CẦU THEO FILE PDF

### PHẦN 1. HƯỚNG DẪN THỰC HÀNH CƠ BẢN (TRANG 60 - 71)
#### Form 1: Quản lý nhóm món ăn (`CategoryForm` / `Form1`)
- **Giao diện:**
  - `lvCategory` (ListView): View = Details, FullRowSelect = True, MultiSelect = False. Các cột: Mã Loại (`chID`), Tên loại món ăn (`chName`), Loại (`chType`).
  - TextBoxes: `txtID` (ReadOnly = True), `txtName`, `txtType`.
  - Buttons: `btnLoad` (Lấy danh sách), `btnAdd` (Thêm), `btnUpdate` (Cập nhật, Enabled = False), `btnDelete` (Xóa, Enabled = False).
  - ContextMenuStrip gán cho `lvCategory`:
    - `tsmDelete` ("Xóa nhóm sản phẩm") -> gọi chức năng Xóa.
    - `tsmViewFood` ("Xem danh sách món ăn") -> mở `FoodForm`.
- **Chức năng:**
  1. *Lấy dữ liệu (SELECT + ExecuteReader):* Truy vấn `SELECT ID, Name, Type FROM Category`, đổ dữ liệu vào `lvCategory`.
  2. *Thêm mới (INSERT + ExecuteNonQuery):* `INSERT INTO Category(Name, [Type]) VALUES (...)`. Reset ô nhập, reload lại danh sách.
  3. *Chọn dòng trên ListView (Click):* Đưa thông tin lên TextBoxes, enable nút Cập nhật và Xóa.
  4. *Cập nhật (UPDATE + ExecuteNonQuery):* Cập nhật thông tin nhóm theo ID, cập nhật lại dòng trên ListView hoặc reload.
  5. *Xóa (DELETE + ExecuteNonQuery):* Xóa nhóm theo ID. Cần xử lý ràng buộc khóa ngoại (nếu nhóm đang chứa món ăn trong bảng `Food`).
  6. *Menu chuột phải:*
     - "Xóa nhóm sản phẩm": Xóa nhóm đang chọn.
     - "Xem danh sách món ăn": Mở `FoodForm` và load các món ăn thuộc nhóm đã chọn.

#### Form 2: Danh sách món ăn theo nhóm (`FoodForm`)
- **Giao diện:**
  - DataGridView `dgvFood` hiển thị các cột: Mã món (`ID`), Tên món (`Name`), Đơn vị tính (`Unit`), Mã nhóm (`FoodCategoryID`), Đơn giá (`Price`), Ghi chú (`Notes`).
- **Chức năng cơ bản:**
  - Hàm `LoadFood(int categoryID)`:
    - Dùng `ExecuteScalar` truy vấn `SELECT Name FROM Category WHERE ID = @categoryID` để gán tiêu đề form: `"Danh sách các món ăn thuộc nhóm: " + catName`.
    - Dùng `SqlDataAdapter` và `DataTable` lấy dữ liệu `SELECT * FROM Food WHERE FoodCategoryID = @categoryID`.
    - Gán `dgvFood.DataSource = dt`.

---

### PHẦN 2. CÁC BÀI TẬP BẮT BUỘC (TRANG 71 - 74)

#### Bài tập 1: Nâng cấp FoodForm (Trang 71)
- Bổ sung 2 nút vào `FoodForm`:
  1. **Nút Save (Lưu / Thêm / Sửa):** Cho phép người dùng thêm dòng mới hoặc sửa đổi trực tiếp dữ liệu trên `dgvFood` và lưu các thay đổi này xuống bảng `Food` trong CSDL (sử dụng `SqlDataAdapter` kết hợp `SqlCommandBuilder`). Tự động điền `FoodCategoryID`.
  2. **Nút Delete (Xóa):** Cho phép xóa dòng đang chọn trên `dgvFood` khỏi bảng `Food`. Bắt ngoại lệ FK nếu món ăn đã xuất hiện trong hóa đơn (`BillDetails`).

#### Bài tập 2: Quản lý và thống kê hóa đơn (`BillsForm` & `BillDetailsForm`) (Trang 71 - 72)
- **Thiết kế Form `BillsForm`:**
  - Hai điều khiển `DateTimePicker`: Chọn khoảng thời gian **Từ ngày** (`dtpFromDate`) **Đến ngày** (`dtpToDate`).
  - Nút tìm kiếm / lọc hoặc tự động lọc khi thay đổi ngày.
  - DataGridView `dgvBills`: Hiển thị danh sách các hóa đơn thỏa mãn điều kiện ngày (`CheckoutDate BETWEEN @fromDate AND @toDate`).
    - Cột hiển thị: Mã HĐ (`ID`), Tên hóa đơn (`Name`), Tên/Mã bàn (`TableID`), Số tiền (`Amount`), Giảm giá (`Discount`), Thuế (`Tax`), Trạng thái (`Status`), Ngày thanh toán (`CheckoutDate`), Nhân viên lập (`Account`).
  - Khu vực tổng hợp / thống kê (Labels hoặc TextBoxes rõ ràng):
    - **Tổng số tiền chưa giảm giá** (Tổng cột Amount).
    - **Tổng số tiền giảm giá** (Tổng `Amount * Discount`).
    - **Thực thu** (Tổng `(Amount - DiscountMoney) + (Amount * Tax)` hoặc theo công thức quy định).
  - Sự kiện **CellDoubleClick** trên DataGridView `dgvBills`:
    - Lấy đúng `ID` hóa đơn của dòng vừa nhấp đúp.
    - Khởi tạo và mở Form `BillDetailsForm(invoiceID)`.
- **Thiết kế Form `BillDetailsForm`:**
  - Nhận tham số `invoiceID`.
  - Hiển thị danh mục các món ăn mua trong hóa đơn: Tên món, Đơn vị tính, Đơn giá, Số lượng, Thành tiền (`Price * Quantity`).

#### Bài tập 3: Quản lý tài khoản (`AccountManager`) (Trang 72)
- **Thiết kế Form `AccountManager`:**
  - Xem danh sách tài khoản theo nhóm quyền (ComboBox lọc theo Role: Administrator, Kế toán, Nhân viên thanh toán, Nhân viên phục vụ, hoặc Tất cả).
  - Lọc theo trạng thái kích hoạt (Active / Inactive / Tất cả).
  - DataGridView hiển thị danh sách tài khoản (`AccountName`, `FullName`, `Email`, `Tell`, `DateCreated`, `RoleName`, `Actived`).
  - Các chức năng thao tác:
    1. **Thêm tài khoản mới:** Thêm vào bảng `Account`, đồng thời có thể phân quyền mặc định vào bảng `RoleAccount`.
    2. **Cập nhật thông tin:** Cập nhật FullName, Email, Tell...
    3. **Reset mật khẩu:** Đặt lại mật khẩu mặc định (ví dụ: `123456` hoặc nhập mật khẩu mới).
    4. **ContextMenu chuột phải trên một tài khoản:**
       - **"Xóa tài khoản":** Không xóa hẳn khỏi bảng `Account` mà đánh dấu tất cả các vai trò của tài khoản này là không kích hoạt (`UPDATE RoleAccount SET Actived = 0 WHERE AccountName = @AccountName`).
       - **"Xem danh sách vai trò":** Mở một Form mới (`AccountRoleForm`) hiển thị danh sách tất cả các vai trò và trạng thái kích hoạt tương ứng của tài khoản được chọn, có thể cho phép bật/tắt (kích hoạt/hủy kích hoạt) vai trò.

#### Bài tập 4: Giao diện chính quản lý nhà hàng & bàn ăn (`MainForm`) (Trang 72 - 74)
- **Thiết kế Form `MainForm`:**
  - Hiển thị danh sách các bàn (từ bảng `Table`): có thể dùng ListView (LargeIcon/Tile) hoặc FlowLayoutPanel chứa các Button bàn, có màu sắc phân biệt bàn Trống (Status = 0) và bàn Có người (Status = 1).
  - Quản lý thông tin bàn:
    1. **Thêm một bàn mới:** Thêm mã bàn, tên bàn, số ghế (`Capacity`), trạng thái.
    2. **Cập nhật thông tin bàn:** Đổi tên bàn, số ghế, trạng thái.
    3. **Xóa một bàn:** Xóa bàn khỏi CSDL (bắt ràng buộc nếu bàn đang có hóa đơn).
  - Xem hóa đơn hiện tại của bàn: Khi chọn một bàn, hiển thị hóa đơn đang mở/chưa thanh toán (`Status = 0`) hoặc hóa đơn mới nhất của bàn đó.
  - **ContextMenu chuột phải trên mỗi bàn:**
    1. **"Xóa bàn":** Xóa bàn khỏi CSDL.
    2. **"Xem danh mục hóa đơn":**
       - Mở một Form mới (`TableBillsForm` hoặc tích hợp):
       - Phía bên trái Form: `ListBox` chứa danh sách các ngày lập hóa đơn của bàn đó (`CheckoutDate`).
       - Khi người dùng nhấn chuột chọn một ngày: Phía bên phải Form hiển thị thông tin chi tiết hóa đơn của ngày đó và danh mục sản phẩm (món ăn) đã mua kèm số lượng, đơn giá, thành tiền.
    3. **"Xem nhật ký mua hàng (nhật ký hóa đơn)":**
       - Thống kê: Tổng số lượng hóa đơn, Tổng số tiền, Tổng thuế, Tổng giảm giá.
       - Hiển thị danh sách chi tiết từng hóa đơn: Ngày lập, Tên nhân viên lập hóa đơn, Tiền hàng, Thuế, Giảm giá... (sử dụng ListView hoặc DataGridView).

---

## IV. BẢNG CHECKLIST CÔNG VIỆC CẦN LÀM ĐỂ HOÀN THÀNH

| STT | Module / Chức năng | Trạng thái hiện tại | Công việc cần làm |
|---|---|---|---|
| **1** | **CategoryForm (Form1)** | Đã có code cơ bản | - Chuẩn hóa giao diện & tên Form<br>- Sửa lỗi ép kiểu `txtType` (0/1 vs text)<br>- Dùng Parameterized Query tránh SQL Injection<br>- Bắt lỗi ngoại lệ FK khi xóa và lỗi click trống ListView |
| **2** | **FoodForm (Bài 1)** | Đã có Save và Delete | - Kiểm tra và hoàn thiện hiển thị Header cột có dấu tiếng Việt<br>- Test kỹ cơ chế thêm/sửa trực tiếp trên DataGridView và nhấn Save<br>- Xử lý xóa món an toàn |
| **3** | **BillsForm (Bài 2)** | Đang làm sai yêu cầu | - Thay 1 DateTimePicker bằng 2 DateTimePicker (Từ ngày - Đến ngày)<br>- Sửa DataGridView hiển thị danh sách từng hóa đơn thay vì 1 dòng tổng<br>- Thiết kế các ô hiển thị thống kê tổng (Tổng chưa giảm, Tổng giảm, Thực thu)<br>- Sửa sự kiện double click truyền đúng `ID` hóa đơn sang `BillDetailsForm` |
| **4** | **BillDetailsForm (Bài 2)** | Đã có code đọc DB | - Test kết nối với `BillsForm`<br>- Định dạng số tiền tiền tệ hiển thị đẹp mắt |
| **5** | **AccountManager (Bài 3)** | Form trống, chưa làm | - Thiết kế giao diện đầy đủ (ComboBox Nhóm/Role, ComboBox Trạng thái, DataGridView)<br>- Viết các hàm nạp dữ liệu, lọc tài khoản theo nhóm & trạng thái<br>- Viết chức năng Thêm, Cập nhật, Reset mật khẩu<br>- Tạo ContextMenu: Xóa tài khoản (Actived = 0), Xem danh sách vai trò (Form phụ) |
| **6** | **MainForm (Bài 4)** | Form trống, chưa làm | - Thiết kế giao diện danh sách bàn ăn (ListView/FlowLayoutPanel)<br>- Các chức năng Thêm, Cập nhật, Xóa bàn<br>- Hiển thị hóa đơn hiện tại của bàn<br>- ContextMenu: Xóa bàn, Xem danh mục hóa đơn (ListBox ngày + chi tiết bên phải), Xem nhật ký hóa đơn (thống kê tổng + danh sách) |
| **7** | **Điều hướng hệ thống (Main Menu)** | Chỉ có Form1 chạy đầu | - Cấu hình menu điều hướng trên Form chính (Menu / MenuStrip hoặc Navigation) giúp người dùng dễ dàng chuyển đổi giữa: Quản lý bàn (`MainForm`), Quản lý danh mục (`CategoryForm`), Quản lý hóa đơn (`BillsForm`), Quản lý tài khoản (`AccountManager`). |
