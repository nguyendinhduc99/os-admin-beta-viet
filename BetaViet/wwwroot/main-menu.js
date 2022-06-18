const fontendMainMenu = [
    {
        name: 'Trang chủ',
        path: '/'
    },
    {
        name: 'Dịch vụ thi công',
        path: '/dich-vu-thi-cong',
        childrenSideBySide: true,
        // customeClass: 'sm:-translate-x-1/6',
        children: [
            {
                name: 'Thi công trọn gói ',
                path: '/tron-goi',
                children: [
                    {
                        name: 'Thi công trọn gói biệt thự',
                        path: '/biet-thu'
                    },
                    {
                        name: 'Thi công trọn gói chung cư',
                        path: '/chung-cu'
                    },
                    {
                        name: 'Thi công trọn gói nhà phố',
                        path: '/lien-ke'
                    },
                ]
            },
            {
                name: 'Thi công xây dựng cơ bản',
                path: '/co-ban',
                children: [
                    {
                        name: 'Thi công xây thô',
                        path: '/xay-tho'
                    },
                    {
                        name: 'Thi công điện nước',
                        path: '/dien-nuoc'
                    },
                    {
                        name: 'Thi công chống thấm',
                        path: '/chong-tham'
                    },
                    {
                        name: 'Thi công mái ngói',
                        path: '/mai-ngoi'
                    },
                    {
                        name: 'Thi công sơn hoàn thiện',
                        path: '/son-hoan-thien'
                    },
                    {
                        name: 'Thi công lắp đặt cửa',
                        path: '/lap-dat-cua-nhom'
                    },
                ]
            },
            {
                name: 'Thi công nội thất',
                path: '/noi-that',
                children: [
                    {
                        name: 'Thi công cửa gỗ',
                        path: '/cua-go'
                    },
                    {
                        name: 'Thi công gỗ nội thất',
                        path: ''
                    },
                    {
                        name: 'Thi công phào chỉ',
                        path: '/phao-chi'
                    },
                    {
                        name: 'Cung cấp gạch ốp lát',
                        path: '/cung-cap-gach-op-lat'
                    },
                    {
                        name: 'Thi công đá',
                        path: '/da'
                    },
                    {
                        name: 'Thi công rèm cửa',
                        path: '/rem-cua'
                    },
                    {
                        name: 'Thi công điều hòa',
                        path: '/dieu-hoa'
                    },
                ]
            },
            {
                name: 'Thi công ngoại thất',
                path: '/ngoai-that',
                children: [
                    {
                        name: 'Thi công sân vườn',
                        path: '/san-vuon'
                    },
                    {
                        name: 'Cung cấp nhôm đúc',
                        path: '/cung-cap-san-pham-nhom-duc'
                    },
                    {
                        name: 'Thi công hồ bơi',
                        path: '/ho-boi'
                    },
                ]
            },
            {
                name: 'Cung cấp Đồ Nội thất / Decor',
                path: '/cung-cap-noi-that-decor',
                children: [
                    {
                        name: 'Cung cấp nội thất nhập khẩu',
                        path: '/cung-cap-noi-that-nhap-khau'
                    },
                    {
                        name: 'Sản xuất đồ nội thất',
                        path: '/san-pham-noi-that'
                    },
                    {
                        name: 'Cung cấp đèn trang trí',
                        path: '/cung-cap-den-trang-tri'
                    },
                    {
                        name: 'Cung cấp đồ decor',
                        path: '/do-decor'
                    },
                ]
            },
            {
                name: 'Tư vấn thiết bị',
                path: '/tu-van-thiet-bi',
                children: [
                    {
                        name: 'Tư vấn thang máy',
                        path: '/thang-may'
                    },
                    {
                        name: 'Tư vấn thiết bị vệ sinh',
                        path: '/thiet-bi-ve-sinh'
                    },
                    {
                        name: 'Tư vấn điện thông minh',
                        path: '/dien-thong-minh'
                    },
                    {
                        name: 'Tư vấn lọc - nóng tổng',
                        path: '/loc-tong-nong-tong'
                    },
                    {
                        name: 'Tư vấn thiết bị điện',
                        path: '/dien'
                    },
                ]
            },
        ]
    },
    {
        name: 'Dự án thiết kế',
        path: '/du-an-thiet-ke',
        redirect: '/du-an-thiet-ke/noi-that',
        children: [
            {
                name: 'Nội thất',
                path: '/noi-that'
            },
            {
                name: 'Kiến trúc',
                path: '/kien-truc'
            },
            {
                name: 'Sân vườn',
                path: '/san-vuon'
            },
            {
                name: 'Xem theo phòng',
                path: '/xem-theo-phong'
            },
            {
                name: 'Toàn cảnh 360',
                path: '/toan-canh-360'
            },
        ]
    },
    // {
    //   name: 'Nội thất',
    //   path: '/du-an-thiet-ke/noi-that',
    //   children: [
    //     {
    //       name: 'Dự án thiết kế',
    //       path: ''
    //     },
    //     {
    //       name: 'Xu hướng thiết kế',
    //       path: '/xu-huong-thiet-ke'
    //     },
    //     {
    //       name: 'Xem theo phòng',
    //       path: '/xem-theo-phong'
    //     },
    //     {
    //       name: 'Toàn cảnh 360',
    //       path: '/toan-canh-360'
    //     },
    //     {
    //       name: 'Khuyến mãi',
    //       path: '/khuyen-mai'
    //     },
    //   ]
    // },
    // {
    //   name: 'Kiến trúc',
    //   path: '/du-an-thiet-ke/kien-truc',
    //   children: [
    //     {
    //       name: 'Dự án kiến trúc',
    //       path: ''
    //     },
    //     {
    //       name: 'Xu hướng thiết kế',
    //       path: '/xu-huong-thiet-ke'
    //     },
    //     {
    //       name: 'Thiết kế sân vườn',
    //       path: '/thiet-ke-san-vuon'
    //     },
    //     {
    //       name: 'Toàn cảnh 360',
    //       path: '/toan-canh-360'
    //     },
    //     {
    //       name: 'Khuyến mãi',
    //       path: '/khuyen-mai'
    //     },
    //   ]
    // },
    {
        name: 'Nhà thiết kế',
        path: '/nha-thiet-ke',
        children: [
            {
                name: 'Đơn vị thiết kế',
                path: '/chi-nhanh'
            },
            {
                name: 'Nhà thiết kế',
                path: ''
            },
        ]
    },
    {
        name: 'Dự án thi công',
        path: '/du-an-thi-cong',
        children: [
            {
                name: 'Tiến độ thi công',
                path: ''
            },
            {
                name: 'Đội thi công',
                path: '/doi-thi-cong'
            },
            {
                name: 'Khu đô thị',
                path: '/khu-do-thi'
            },
        ]
    },
    {
        name: 'Đơn vị thành viên',
        path: '/don-vi-thanh-vien',
    },
    {
        name: 'Showroom',
        path: 'https://galaxycentre.vn',
    },
    {
        name: 'Nhà xưởng',
        path: '/nha-xuong',
    },
    {
        name: 'Lợi thế',
        path: '/loi-the',
        children: [
            {
                name: 'Quy mô công ty hàng đầu',
                path: '/quy-mo-cong-ty'
            },
            {
                name: 'Năng lực thiết kế hàng đầu',
                path: '/nang-luc-thiet-ke'
            },
            {
                name: 'Năng lực thi công trọn gói hàng đầu',
                path: '/nang-luc-thi-cong'
            },
            {
                name: 'Showroom nội thất nhập khẩu cao cấp',
                path: '/showroom-noi-that-cao-cap'
            },
            {
                name: 'Nhà máy sản xuất nội thất gỗ',
                path: '/nha-may-san-xuat'
            },
            {
                name: 'Chăm sóc khách hàng tận tâm',
                path: '/cham-soc-khach-hang'
            },
            {
                name: 'Giám sát công trình nghiêm ngặt',
                path: '/giam-sat-cong-trinh'
            },
            {
                name: 'Chính sách bảo hành uy tín',
                path: '/chinh-sach-bao-hang'
            },
        ]
    },
    {
        name: 'BetaViet TV',
        path: '/betaviet-tv',
        children: [
            {
                name: 'Video công trình thực tế',
                path: '/video-cong-trinh-thuc-te'
            },
            {
                name: 'Video hoạt động nội bộ',
                path: '/video-hoat-dong-noi-bo'
            },
            {
                name: 'Video phối cảnh nội- ngoại thất',
                path: '/video-phoi-canh-noi-ngoai-that'
            },

        ]
    },
    {
        name: 'Xem thêm',
        path: '/xem-them',
        childrenSideBySide: true,
        // customeClass: 'sm:-translate-x-2/3',
        children: [
            {
                name: 'Kiến thức',
                path: '/kien-thuc',
                children: [
                    {
                        name: 'Thiết kế',
                        path: '/thiet-ke'
                    },
                    {
                        name: 'Thi công xây dựng',
                        path: '/thi-cong-xay-dung'
                    },
                    {
                        name: 'Thi công nội thất',
                        path: '/thi-cong-noi-that'
                    },
                    {
                        name: 'Mua sắm',
                        path: '/mua-sam'
                    },
                    {
                        name: 'Câu hỏi thường gặp',
                        path: '/cau-hoi-thuong-gap'
                    },
                    {
                        name: 'Phong thuỷ',
                        path: '/phong-thuy'
                    },
                ]
            },
            {
                name: 'Về BetaViet',
                path: '/ve-betaviet',
                children: [
                    {
                        name: 'Betaviet- Giá trị- Niềm tin',
                        path: '/gia-tri-niem-tin'
                    },
                    {
                        name: 'Lịch sử phát triển',
                        path: '/lich-su-phat-trien'
                    },
                    {
                        name: 'Cơ cấu tổ chức',
                        path: '/co-cau-to-chuc'
                    },
                    {
                        name: 'Cảm nhận khách hàng',
                        path: '/cam-nhan-khach-hang'
                    },
                    {
                        name: 'Báo chí nói về Betaviet Group',
                        path: '/bao-chi'
                    },
                    {
                        name: 'Lan tỏa cộng đồng',
                        path: '/lan-toa-cong-dong'
                    },
                    {
                        name: 'Tuyển dụng',
                        path: '/tuyen-dung'
                    },
                    {
                        name: 'Liên hệ với Betaviet',
                        path: '/lien-he'
                    },
                ]
            },
        ]
    },
    // {
    //   name: 'Nhận mẫu miễn phí',
    //   path: '/nhan-mau-thiet-ke',
    //   customClass: 'btn btn-danger rounded-full whitespace-no-wrap btn-sm self-center'
    // },
]