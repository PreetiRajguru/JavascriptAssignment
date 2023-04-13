function showTextbox() {
    var textbox = document.getElementById("myTextbox");
    textbox.style.display = "block"; // Show the textbox
}

function getFormValues() {
    const myForm = document.getElementById("myForm");
    myForm.addEventListener("submit", function (event) {
        event.preventDefault();

        console.log("Booking Name : " + document.getElementById("bookingname").value);

        const selectConsignee = document.getElementById("consignee");
        const selectedConsignee = selectConsignee.value;
        console.log("Consignee : " + selectedConsignee);

        const selectSupplier = document.getElementById("supplier");
        const selectedSupplier = selectSupplier.value;
        console.log("Supplier : " + selectedSupplier);

        const radioVal = document.querySelector('input[name="options"]:checked');
        if (radioVal && radioVal.value) {
            console.log("Incoterms : " + radioVal.value)
        }

        console.log("Less Than Container");
        console.log("Total Weight : " + document.getElementById("totalweight").value + "kg");
        console.log("Total Volume : " + document.getElementById("totalvolume").value + "cbm");
        const selectPackage = document.getElementById("packagetype");
        const selectedType = selectPackage.value;
        console.log("Package Type : " + selectedType);
        console.log("Total Quantity : " + document.getElementById("totalquantity").value);

        console.log("Full Containers");
        console.log("Number of Containers : " + document.getElementById("nocontainers").value);
        const selectContainerType = document.getElementById("fullcontainertype");
        const selectedCType = selectContainerType.value;
        console.log("Container Type : " + selectedCType);
        console.log("Total Weight : " + document.getElementById("fulltotalweight").value + "kg");
        console.log("Total Volume : " + document.getElementById("fulltotalvolume").value + "cbm");
        const selectPackageType = document.getElementById("fullpackagetype");
        const selectedPType = selectPackageType.value;
        console.log("Package Type : " + selectedPType);
        console.log("Total Quantity : " + document.getElementById("fulltotalquantity").value);

        console.log("Origin Address : " + document.getElementById("originAddress").value);

        const selectPort = document.getElementById("port");
        const selectedPort = selectPort.value;
        console.log("Port : " + selectedPort);

        const radioValue = document.querySelector('input[name="optionsyesno"]:checked');
        if (radioValue && radioValue.value) {
            console.log("Origin to Port ? : " + radioValue.value)
        }

        console.log("Destination Address : " + document.getElementById("destinationAddress").value);

        console.log("Added Products : " + document.getElementById("myTextbox").value);

        const checkboxes = document.querySelectorAll('input[type="checkbox"]');

        checkboxes.forEach((checkbox) => {
            if (checkbox.checked) {
                console.log("Hazardous Materials : " + checkbox.value);
            };
        });

        const text_date_range = document.getElementById("text_date_range").value;
        console.log("Date Range : " + text_date_range)

        myForm.reset();
    });

}

$(function () {
    var today = new Date();
    var currentYear = today.getFullYear();
    var currentMonth = today.getMonth();
    var currentDay = today.getDate();

    $('input[name="daterange"]').daterangepicker({
        opens: 'left',
        minDate: new Date(currentYear, currentMonth, currentDay),
        maxDate: new Date(currentYear, currentMonth + 1, currentDay),
        placeholder: "select date range"
    })
});
var triggerTabList = [].slice.call(document.querySelectorAll('#myTab a'))
triggerTabList.forEach(function (triggerEl) {
    var tabTrigger = new bootstrap.Tab(triggerEl)

    triggerEl.addEventListener('click', function (event) {
        event.preventDefault()
        tabTrigger.show()
    })
})