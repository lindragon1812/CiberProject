
$(document).ready(function () {
    var modal = document.getElementById("myModal");
    //Button Create New Order
    var btn = document.getElementById("btnOrder");

    //Nút đóng popup
    var span = document.getElementsByClassName("close")[0];

    //Khi click thêm order thì bật popup và load các thông tin
    btn.onclick = function () {
        modal.style.display = "block";
        loadProduct();
        loadCustomer();
    }

    //Đóng popup
    span.onclick = function () {
        modal.style.display = "none";
    }

    //Đóng popup khi click ra ngoài
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
    loadData();
    //Click vào nút tạo order
    $('#btnCreateOrder').click(function () {
        insertData();
    });
});

function insertData() {
    let createdDate = new Date($('#formOrderDate').val());
    $.ajax({
        type: "POST", url: "/api/OrderApi/OrderProduct",
        data: JSON.stringify(
            {

                ProductId: parseInt($('#productSelect').find(':selected').val()),
                CustomerId: parseInt($('#customerSelect').find(':selected').val()),
                Amount: parseInt($('#formAmount').val()),
                CreatedDate: createdDate.toJSON(),

            }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.data == 1 && data.code == 1) {
                //Load lại
                location.reload();

            } else {
                console.log(data.message);
                alert(data.message);

            }

        }
    });
}

function loadData() {
    let tableBody = $(".table-body");

    $.ajax({
        type: "GET", url: "/api/OrderApi/GetOrder", data: {},
        success: function (data) {
            data.forEach(x => {
                let createdDAte = new Date(x.createdDate);
                let stringAppend = ` <tr>
                        <td>${x.productName}</td>
                        <td>${x.categoryName}</td>
                        <td>${x.customerName}</td>
                        <td>${createdDAte.toLocaleDateString('en-GB', {
                            day: 'numeric', month: 'short', year: 'numeric'
                        }).replace(/ /g, '-') }</td>
                        <td>${x.amount}</td>
                    </tr>`;
                tableBody.append(stringAppend);

            });
            $('#example').DataTable({
                "columnDefs": [
                    { "targets": [1, 2, 3], "searchable": false }
                ]
            });

        }
    });

}

function loadProduct() {
    let productSelect = $("#productSelect");
    $.ajax({
        type: "GET", url: "/api/OrderApi/GetProduct", data: {},
        success: function (datas) {
            datas.forEach(x => {
                const newOption = document.createElement("option");
                newOption.value = x.productId;
                newOption.text = x.productName;
                productSelect.append(newOption);

            });
        }
    });
}

function loadCustomer() {
    let customerSelect = $("#customerSelect");
    $.ajax({
        type: "GET", url: "/api/OrderApi/GetCustomer", data: {},
        success: function (datas) {
            datas.forEach(x => {
                const newOption = document.createElement("option");
                newOption.value = x.customerId;
                newOption.text = x.customerName;
                customerSelect.append(newOption);

            });
        }
    });
}





