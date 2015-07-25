

function btLoginClick() {
    DoAction("/api/login", { Pwd: '123', Name: '0100001' }, "POST", function (d) {
        alert(d.Data.UserName);
    });
    
}

function btGetClick() {

    DoAction("/api/TakeOutGoods", { PageIndex: 0, PageSize: 15, StartDate: '2015-07-25 00:00:00', EndDate: '2015-07-25 23:59:59' }, "Get", function (d) {
        alert(d.Data.length);
    });
}


function btTakeOverClick() {

    DoAction("/api/TakeOutGoods/Over", { Code: '2001001125,2001001124,2001001122' }, "POST", function (d) {
        alert(d.Success);
    });
}

function btAddClick() {

    DoAction("/api/TakeOutGoods/Add", { Person: '张飞', StartStation: "江夏", EndStation: "荆州", Num: 8, Address: '天南路32号刘表府', Source: "手机下单",Status:'New' }, "POST", function (d) {
        alert(d.Msg);
    });
}

function btEditClick() {


    DoAction("/api/TakeOutGoods/Edit", { Code: 1000063, Person: '赵云', StartStation: "许昌", EndStation: "荆州", Num: 4, Address: '帝都路132号曹操府', Source: "手机下单", ServiceType: "站点送货" }, "POST", function (d) {
        alert(d.Msg);
    });
}

function btPrintClick() {

    DoAction("/api/TakeOutGoods/print", { Code: 1000063 }, "POST", function (d) {
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

    DoAction("/api/TakeOutGoods/GetByCode", { Codes: '2001000029,2001000028,2001000030' }, "Get", function (d) {
        alert(d.Data.length);
    });
}

function btDeleteClick() {

    DoAction("/api/TakeOutGoods/Delete", { Codes: '2001000053,2001000054,2001000052' }, "Post", function (d) {
        alert(d.Data.length);
    });
}

function DoAction(url, data, type, su) {
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