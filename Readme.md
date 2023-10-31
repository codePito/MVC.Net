## Controller 
- Là 1 lớp kế thừa từ lớp Controller" Microft.AspNetCore.Mvc.Controller
- Action trong controller la 1 phuong public (khong duoc static)
- Action tra ve bat ki kieu du lieu nao, thuong la IActionResult
- Cac dich vu inject vao controller thong qua ham tao

## View
- La file .cshtml
- View cho Action luu tai: /Views/ControllerName/ActionName.cshtml

## Truyen du lieu cho View
- Model 
- ViewData
- ViewBag
- TempData
- 
## Areas
- Là tên dùng để routing 
- Là cấu trúc thư mục chứa M.V.C
- Thiết lập area cho controller bằng [Area("AreaName")]
- Tạo cấu trúc thư mục 
dotnet aspnet-codegenerator area ProductManage

