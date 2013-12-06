
function ViewModel() {
    var self = this;
    self.Inventory = ko.observableArray([]);
    self.Inventorydata = ko.observableArray();   // Contains the list of products
    self.Create = function () {
        if ($("#txtItemName").val() != "" && $("#txtReorderPoint").val() != "") {
            var data = { "ItemName": $("#txtItemName").val(), "ReorderPoint": $("#txtReorderPoint").val(), "UpdateCase": $("#UpdateCase").val(), "Id": $("#InventoryId").val() };
            $.ajax({
                type: "Post",
                url: "/Home/Post/",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if ($("#InventoryId").val() != "") {
                        bootbox.alert("Records Updated Sucessfully!");
                    }
                    else {
                        bootbox.alert("Your Data Saved Sucessfully!");
                    }

                    $("#customerEdit").hide();
                    viewModel.Inventory(result);
                    $("#UpdateCase").val("");
                    $("#InventoryId").val("");
                    clearfields()
                }, error: function (xhr, desc, err) {
                    bootbox.alert("Error " + xhr);
                    bootbox.alert("Desc: " + desc + "\nErr:" + err);
                }
            });
        } else {
            bootbox.alert("All fields are required!");
            return false;
        }
    }

    $.ajax({
        type: "POST",
        url: "/Home/Get",
        contentType: "application/json; charset=utf-8",
        data: null,
        dataType: "json",
        success: function (data) {
            viewModel.Inventory(data);
        },
        error: function (xhr, desc, err) {
            bootbox.alert("Error " + xhr);
            bootbox.alert("Desc: " + desc + "\nErr:" + err);
        }

    });
    function rebinInventory() {
        $.ajax({
            type: "POST",
            url: "/Home/Get",
            contentType: "application/json; charset=utf-8",
            data: null,
            dataType: "json",

            success: function (data) {
                viewModel.Inventory(data);
            },
            error: function (xhr, desc, err) {
                bootbox.alert("Error " + xhr);
                bootbox.alert("Desc: " + desc + "\nErr:" + err);
            }

        });
    }
}
function Updatedata(obj) {
    $.ajax({
        type: "POST",
        url: "/Home/GetDatabyID?id=" + $(obj).attr("id"),
        contentType: "application/json; charset=utf-8",
        data: null,
        dataType: "json",
        success: function (data) {
            $("#txtItemName").val(data.ItemName);
            $("#txtReorderPoint").val(data.ReorderPoint);
            $("#hiddenid").val(data.Id);
            $("#customerEdit").show();
            $("#UpdateCase").val("UpdateCase");
            $("#InventoryId").val(data.Id);
        },
        error: function (xhr, desc, err) {
            bootbox.alert("Error " + xhr);
            bootbox.alert("Desc: " + desc + "\nErr:" + err);
        }

    });
}

function Delete(obj) {

    bootbox.confirm("Are you sure to delete this record?", function (result) {
        if (result) {
            $.ajax({
                type: "Post",
                url: "/Home/Delete?id=" + $(obj).attr("id"),
                data: null,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (result) {
                    $("#customerEdit").hide();
                    viewModel.Inventory(result);
                }, error: function (xhr, desc, err) {
                    bootbox.alert("Error " + xhr);
                    bootbox.alert("Desc: " + desc + "\nErr:" + err);
                }
            });
        } else {
            $("#myModal").hide();
        }
    });

}
$("#btncancle").live("click", function () {
    $("#customerEdit").hide();
    clearfields();
});
function showhide() {
    $("#customerEdit").css("display", "block");
}
var viewModel = new ViewModel();
ko.applyBindings(viewModel);
function clearfields() {
    $("#txtItemName").val("");
    $("#txtReorderPoint").val("")
}
