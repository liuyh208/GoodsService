

function btLoginClick() {
    DoAction("/api/login", { Pwd: '1', Name: '赵凤达' }, "POST", function (d) {
        alert(d.Data.UserName);
    });
    
}

function btGetClick() {

    DoAction("/api/TakeOutGoods", { PageIndex: 0, PageSize: 15, StartDate: '2015-08-06 00:00:00', EndDate: '2015-08-06 23:59:59' }, "Get", function (d) {
        alert(d.Data.length);
    });
}


function btTakeOverClick() {

    DoAction("/api/TakeOutGoods/Over", { Code: '1000000000,1000000001' }, "POST", function (d) {
        alert(d.Success);
    });
}

function btAddClick() {

    DoAction("/api/TakeOutGoods/Add", { Person: '张飞', StartStation: "江夏", EndStation: "荆州", Num: 8, Address: '天南路32号刘表府', Source: "手机下单",Status:'New' }, "POST", function (d) {
        alert(d.Msg);
    });
}

function btEditClick() {


    DoAction("/api/TakeOutGoods/Edit", { Code: 1000000000, Person: '赵云', StartStation: "许昌", EndStation: "荆州", Num: 4, Address: '帝都路132号曹操府', Source: "手机下单", ServiceType: "站点送货" }, "POST", function (d) {
        alert(d.Msg);
    });
}

function btPrintClick() {

    DoAction("/api/TakeOutGoods/print", { Code: 1000000000 }, "POST", function (d) {
        alert(d.Success);
    });
}


function btStartClick() {

    DoAction("/api/StartStation", null, "Get", function (d) {
        alert(d.Data.length);
    });
}

function btEndClick() {

    DoAction("/api/endStation", null, "Get", function (d) {
        alert(d.Data.length);
    });
}
function btCustomerClick() {

    DoAction("/api/Customer", null, "Get", function (d) {
        alert(d.Data.length);
    });
}

function btGetByCodeClick() {

    DoAction("/api/TakeOutGoods/GetByCode", { Codes: '1000000000,1000000001' }, "Get", function (d) {
        alert(d.Data.length);
    });
}

function btDeleteClick() {

    DoAction("/api/TakeOutGoods/Delete", { Codes: '1000000000,1000000001' }, "Post", function (d) {
        alert(d.Data.length);
    });
}

function DoAction(url, data, type, su) {
    //"http://116.90.85.94:8010" +
    $.ajax({
        url: url,
        data: data,
        dataType: "json",
        type: type,
        error: function (xmlhttprequest, textStatus, errorThrown) {
            alert(errorThrown);
        },
        success: function (data) {
            su(data);
        }
    });
}