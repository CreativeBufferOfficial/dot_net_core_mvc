function prepareEditModal(productId, productName, productDiscription, productPrice, productStock) {
    $("#hiddenfield").val(productId);
    $("#productName").val(productName);
    $("#productDescription").val(productDiscription);
    $("#productPrice").val(productPrice);
    $("#productStock").val(productStock);
    $('#productModal').modal('show');

}

// Function to handle button click
document.getElementById("saveButton").addEventListener("click", function () {
    var id = $("#hiddenfield").val();
    var productName = $('#productName').val();
    var productDescription = $('#productDescription').val();
    var productPrice = $('#productPrice').val();
    var productStock = $('#productStock').val();

    if (productName == '') {
        var value = $('#span').text('Product Name is required');
        return;
    }
    if (productPrice == '') {
        var value = $('#span1').text('Product Price is required');
        return;
    }
    if (productStock == '') {
        var value = $('#span2').text('Product Stock is required');
        return;
    }
    
        $.ajax({
            type: "POST",
            url: "/Product/CreateProduct",
            data: {
                Id: id,
                ProductName: productName,
                ProductDescription: productDescription,
                ProductPrice: productPrice,
                ProductStock: productStock
            },
            success: function (response) {
                /*   location.reload();*/
              

            },
            error: function () {
                alert("Error in the AJAX request.");
            }
        });

        $("#productModal").modal("hide");
   
});

function openModal() {
    $('#productModal').modal('show');
}
function openModal1() {
    $('#productModal').modal('hide');
}


function saveProduct() {
    // Here you can add code to save the product
    // For example, you can retrieve values from the modal inputs
    var productName = $('#productName').val();
    var productDescription = $('#productDescription').val();
    var productPrice = $('#productPrice').val();
    var productStock = $('#productStock').val();

    console.log('Product Name:', productName);
    console.log('Product Description:', productDescription);
    console.log('Product Price:', productPrice);
    console.log('Product Stock:', productStock);

    // Once saved, you can close the modal
    $('#productModal').modal('hide');
}