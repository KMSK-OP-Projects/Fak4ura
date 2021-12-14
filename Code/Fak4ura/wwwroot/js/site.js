
var CounterPartyList

// HIDE-SHOW lOGIN/REGISTER/RECOVER PAGE   @LOGIN PAGE
document.addEventListener("DOMContentLoaded", function ()
{
//$(document).ready(function () {
	$("#register-form").hide();
	$("#forgot-form").hide();

	$(".register-form-link").click(function ()
	{
		$("#login-form").slideUp(0);
		$("#forgot-form").slideUp(0)
		$("#register-form").fadeIn(500);
	});

	$(".login-form-link").click(function ()
	{
		$("#register-form").slideUp(0);
		$("#forgot-form").slideUp(0);
		$("#login-form").fadeIn(500);
	});

	$(".forgot-form-link").click(function ()
	{
		$("#login-form").slideUp(0);
		$("#forgot-form").fadeIn(500);
	});


	if (document.getElementById("passRecoveryResult")) {
		if (document.getElementById("passRecoveryResult").value.substring(0, 1) == "⛌") {
			$("#login-form").slideUp(0);
			$("#forgot-form").fadeIn(500);
		}
	}

	if (document.getElementById("passRegistrationResult")) {
		if (document.getElementById("passRegistrationResult").value.substring(0, 1) == "⛌") {
			$("#login-form").slideUp(0);
			$("#forgot-form").slideUp(0)
			$("#register-form").fadeIn(500);
		}
	}

	//AjaxGetConterPartyNames();

	//NOTIFICATIONS
	LoginResult();
	RecoveryResult();
	RegistrationResult();
	EditUserDatarESULT();
	AddCounterPartyResult();
	EditCounterPartyResult();
});


//Create PDf from HTML...
//<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.5.3/jspdf.min.js"></script>
//<script type="text/javascript" src="https://html2canvas.hertzen.com/dist/html2canvas.js"></script>
function CreatePDFfromHTML() {
	if (document.getElementById("logo-upload").value != "")
		document.getElementById("invoiceLogoContainer").classList.remove("hide4Pdf");
	$(".hide4Pdf").css('visibility', 'hidden');
	var fileName = document.getElementById("generatgedInvoiceId").value;
	var HTML_Width = $(".html-content").width();
	var HTML_Height = $(".html-content").height();
	var top_left_margin = 15;
	var PDF_Width = HTML_Width + (top_left_margin * 2);
	var PDF_Height = (PDF_Width * 1.5) + (top_left_margin * 2);
	var canvas_image_width = HTML_Width;
	var canvas_image_height = HTML_Height;

	var totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;

	html2canvas($(".html-content")[0]).then(function (canvas) {
		var imgData = canvas.toDataURL("image/jpeg", 1.0);
		var pdf = new jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
		pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);
		for (var i = 1; i <= totalPDFPages; i++) {
			pdf.addPage(PDF_Width, PDF_Height);
			pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height * i) + (top_left_margin * 4),
				canvas_image_width, canvas_image_height);
		}
		pdf.save(fileName+".pdf");
		$(".hide4Pdf").css('visibility', 'visible');

	});
}





/* Ajax on Get */ 
function AjaxGetTestx() {
	
	var options = {};
	options.url = "/Invoice/GenerateInvoice?handler=Test";
	options.type = "GET";
	options.dataType = "json";
	options.success = function (data) {
		$("#generatgedInvoiceId").val(data);
	};
	options.error = function () {
		alert("error")
	};
	$.ajax(options);
}

/* Ajax on Get // Gets CounterPartyDataList for select in generateInvoice */
function AjaxGetConterPartyNames() {
	var options = {};
	options.url = "/Invoice/GenerateInvoice?handler=SelectAllCounterParty";
	options.type = "GET";
	options.dataType = "json";
	options.success = function (data) {
		CounterPartyList = data;
		data.forEach(function (element) {
			$("#selectKontrahentInput").append("<option>"
				+ element.nazwaFirmy + "</option>");  /* Why z zmienna z malej?*/
		});
	};
	options.error = function () {
		alert("Error while making Ajax call!");
    };
	$.ajax(options);
}


function fillCounterPartyInsertData(sender) {
	//alert(sender.selectedIndex);
	var select = CounterPartyList[sender.selectedIndex - 1]
	document.getElementById("gInvoiceNNazwa/Firma").value = select.nazwaFirmy;
	document.getElementById("gInvoiceNAdres").value = select.ulica;
	//document.getElementById("gInvoiceNMiejscowosc").value = select.miejscowosc;
	document.getElementById("gInvoiceNKodPocztowy").value = select.kodPocztowy;
	document.getElementById("gInvoiceNNIP").value = select.nip;
	//document.getElementById("gInvoiceNTelefon").value = select.telefon;
	document.getElementById("gInvoiceNEmail").value = select.email;
}










function printWindow()
{
	window.print();
}

//REGISTER PAGE
function checkIfPasswordIsEqual(sender)
{
	var pass = document.getElementById("pass").value;
	var confirmPass = document.getElementById("confirmPass").value;
	var displayconfirmPassError = document.getElementById("displayconfirmPassError");
	var displayPassError = document.getElementById("displayPassError");
	document.getElementById("registerFormSubmit").disabled = false;
	if (pass && confirmPass)
	{
		displayPassError.innerText = "";
		displayconfirmPassError.innerText = "";
		if (pass != confirmPass)
		{
			document.getElementById(sender).innerText = "Podane hasła się nie zgadzają!";
			document.getElementById(sender).style.color = "tomato";
			document.getElementById("registerFormSubmit").disabled = true;
		}
	}
}

function checkIfPasswordIsEqual2(sender) {
	var pass = document.getElementById("changePassWindowPasswordIn").value;
	var confirmPass = document.getElementById("changePassWindowPasswordIn2").value;
	var displayconfirmPassError = document.getElementById("displayconfirmChangePassError");
	var displayPassError = document.getElementById("displayChangePassError");
	document.getElementById("saveNewPasswordBtn").disabled = false;
	if (pass && confirmPass) {
		displayPassError.innerText = "";
		displayconfirmPassError.innerText = "";
		if (pass != confirmPass) {
			document.getElementById(sender).innerText = "Podane hasła się nie zgadzają!";
			document.getElementById(sender).style.color = "tomato";
			document.getElementById("saveNewPasswordBtn").disabled = true;
		}
	}
}


//CREATES POPPINGUP ALERT 
function getAlert(msg, duration)
{
	var el = document.createElement("div");
	el.setAttribute("style", "position:absolute; text-align:center; top: 800px\
			;left: 50%;transform: translate(-50%, 0); background: rgba(225, 215, 255, 0.95)\
			;font-size:29px; color:black ; border-radius: 9px; padding:15px\
			; box-shadow: 0px 3px 15px rgba(0,0,0,0.1);");
	el.innerHTML = msg;

	setTimeout(function ()
	{
		el.parentNode.removeChild(el);
	}, duration);
	document.body.appendChild(el);
}


//CREATES SLIDEDOWN ALERT 
function getAlertSlideDown(msg)
{
	var el = document.createElement("div");
	el.id = "ele";

	/*// UPPER SMALLER SLIDER CENTER
	el.setAttribute("style", "position:absolute; text-align:center; top: 0px\
			;left: 50%;transform: translate(-50%, 0); background: rgba(92, 100, 106, 1)\
			;font-size:23px; color:#fff ; border-radius: 0 0 10px 10px; padding:12px 40px 6px 40px;display:none;\
			;");
			*/
	/*// UPPER SLIDER ENTIRE WIDTH 
	el.setAttribute("style", "position:absolute; text-align:center; top: 0px\
			;width:100%; background: rgba(255, 255, 255, 0.92)\
			;font-size:23px; color:#000 ; border-radius: 0 0 0 0; padding:9px 50px 14px 0;display:none;\
			;");
	el.classList.add("box-shadow");
	*/

	// BOTTOM SMALL SLIDER ON CENTER
	el.setAttribute("style", "position: fixed; ; text-align:center; bottom: 25px\
			;left: 50%;transform: translate(-50%, 0); background: rgba(0, 0, 0, 0.8)\
			;font-size:20px; color:#fff ; border-radius: 7px; padding:12px 40px ;display:none;\
			;");
	el.classList.add("box-shadow");
	

	el.innerHTML = msg;
	document.body.appendChild(el);
	setTimeout(function ()
	{
		$("#ele").slideDown(400);
	}
		, 700);

	setTimeout(function ()
	{
		$("#ele").slideUp(400);
	}
		, 3500);

	setTimeout(function ()
	{
		document.body.removeChild(el);
	}
	, 4300);

}


//DISPLAY RESULT OF PASSWORD RECOVERY
function RecoveryResult()
{
	if (document.getElementById("passRecoveryResult"))
	{
		if (document.getElementById("passRecoveryResult").value != "")
		{
			var x = document.getElementById("passRecoveryResult").value;
			getAlertSlideDown(x);
			x.value = "";
		}

	}
}

//DISPLAY RESULT OF LOGIN
function LoginResult() {
	if (document.getElementById("passLoginResult"))
	{
		if (document.getElementById("passLoginResult").value != "")
		{
			var x = document.getElementById("passLoginResult").value;
			getAlertSlideDown(x);
			x.value = "";
		}
	}
}

//DISPLAY RESULT OF REGISTRATION
function RegistrationResult() {
	if (document.getElementById("passRegistrationResult")) {
		if (document.getElementById("passRegistrationResult").value != "") {
			var x = document.getElementById("passRegistrationResult").value;
			getAlertSlideDown(x);
			x.value = "";
		}
	}
}

//DISPLAY RESULT OF EDITUSERDATA
function EditUserDatarESULT() {
	if (document.getElementById("passEditUserDataResult")) {
		if (document.getElementById("passEditUserDataResult").value != "") {
			var x = document.getElementById("passEditUserDataResult").value;
			getAlertSlideDown(x);
			x.value = "";
		}
	}
}

//DISPLAY RESULT OF ADDCOUNTERPARTY
function AddCounterPartyResult() {
	if (document.getElementById("passAddCounterPartyResult")) {
		if (document.getElementById("passAddCounterPartyResult").value != "") {
			var x = document.getElementById("passAddCounterPartyResult").value;
			getAlertSlideDown(x);
			x.value = "";
		}
	}
}

//DISPLAY RESULT OF EDITCOUNTERPARTY
function EditCounterPartyResult() {
	if (document.getElementById("passEditCounterPartyResult")) {
		if (document.getElementById("passEditCounterPartyResult").value != "") {
			var x = document.getElementById("passEditCounterPartyResult").value;
			getAlertSlideDown(x);
			x.value = "";
		}
	}
}



//ADDING IMAGE @USERDATA PAGE
function onUserDataImageSelected(event)
{
	$("#userAccountLogoInput").fadeIn(70);
	var selectedFile = event.target.files[0];
	var reader = new FileReader();

	var imgElement = document.getElementById("logoImage");
	imgElement.title = selectedFile.name;

	reader.onload = function (event)
	{
		imgElement.src = event.target.result;
	};

	reader.readAsDataURL(selectedFile);
	imgElement.src = "";

	setTimeout(function ()
	{
		$("#userAccountLogoInput").fadeOut(700);
	}
		, 600);

	setTimeout(function () {
		getAlertSlideDown("✓ Dodano logo");
	}
		, 800);

	
	//$("#userAccountLogoInput").animate({ "marginLeft": -$('#AccountUserDataModelDiV').width() + -$('#userAccountLogoInput').width() }, "slow");
	//$("#logoImage").animate({ "height": "-=300px" }, "slow");
	
}

//ADDING IMAGE @GENERATE INVOCIE PAGE
function onInvoiceLogoImageSelected(event) {
	var selectedFile = event.target.files[0];
	var reader = new FileReader();

	var imgElement = document.getElementById("invoiceLogoImage");
	imgElement.title = selectedFile.name;

	reader.onload = function (event) {
		imgElement.src = event.target.result;
	};

	reader.readAsDataURL(selectedFile);
	imgElement.src = "";
	document.getElementById("invoiceLogoInputLabel").style.visibility = "hidden";
	document.getElementById("invoiceLogoDiv").style.border = "none";
	document.getElementById("invoiceLogoDiv").style.opacity = 1;


}


//ADD ROWS TO PRODUKT TABLE ON INDEX PAGE      ##################################INDEX PAGE
document.getElementById("addRowButton").onclick = function ()
{
	var amountOfRows = document.getElementById("serviceProduktTable").rows.length;


	var jedostkaColumn = document.getElementById("jedostkaColumn").innerHTML;
	var vatColumn = document.getElementById("vatColumn").innerHTML;
	var table = document.getElementById("serviceProduktTable");
	var row = table.insertRow()

	var cell = row.insertCell();
	cell.innerHTML = '<input class="form-control bg-lights serviceProduktInput productTableRow'
		+ amountOfRows + ' " type="text" value="' + amountOfRows + '." readonly/>';
	cell = row.insertCell();
	cell.innerHTML = '<textarea class="form-control bg-lights serviceProduktInput productTableRow'
		+ amountOfRows + '" style="height:32px;overflow:hidden"  oninput="auto_grow(this)"></textarea>';
	cell = row.insertCell();
	cell.innerHTML = '<input name="quantityCol" class="form-control bg-lights serviceProduktInput productTableRow'
		+ amountOfRows + '" value=1 type="text" oninput="updatePriceValues(this), getAmountToPay()"/>';

	cell = row.insertCell();
	cell.innerHTML = jedostkaColumn;

	cell = row.insertCell();
	cell.innerHTML = '<input name="nettoAmountCol" class="form-control bg-lights serviceProduktInput productTableRow'
		+ amountOfRows + '" type="text" oninput="updatePriceValues(this), getAmountToPay()" />'
	cell = row.insertCell();
	cell.innerHTML = '<input  name="vatAmountCol" readonly class="form-control bg-lights productTableRow'
		+ amountOfRows + ' serviceProduktInput"  oninput="updatePriceValues(this), getAmountToPay()"/>'
	cell = row.insertCell();
	cell.innerHTML = '<input   name="bruttoAmountCol" class="form-control bg-lights serviceProduktInput productTableRow'
		+ amountOfRows + '" type="text" oninput="updatePriceValues(this), getAmountToPay()"/>'
	updateVatColumn();

	//window.print();
};

function getTableRowValues() {
	var table = document.getElementById("serviceProduktTable");
	var lastRowIndex = table.rows.length - 1;
	var lastCellIndex = table.rows[lastRowIndex].cells.length - 1;

	//var column5Row3 = table.rows[1].cells[6].lastElementChild.value //lastElement, because of input inside cell
	
	var productService = [];
	var quantity = [];
	var unit = [];
	var priceNet = [];
	var InvoiceId = document.getElementById("generatgedInvoiceId").value;
	for (let i = 0; i < lastRowIndex; i++) {
		productService[i] = table.rows[i + 1].cells[1].lastElementChild.value
		quantity[i] = table.rows[i + 1].cells[2].lastElementChild.value
		unit[i] = table.rows[i + 1].cells[3].lastElementChild.value
		priceNet[i] = table.rows[i + 1].cells[4].lastElementChild.value
	}

	

	$.ajax({
		type: "POST",
		url: "/Invoice/GenerateInvoice?handler=GetLastRowValues",
		beforeSend: function (xhr) {
			xhr.setRequestHeader("XSRF-TOKEN",
				$('input:hidden[name="__RequestVerificationToken"]').val());
		},
		data: {
			"productService": productService,
			"quantity": quantity,
			"unit": unit,
			"priceNet": priceNet,
			"InvoiceId": InvoiceId
		},
		
		failure: function (response) {
			getAlertSlideDown("⛌ Ajax: Nieudana operacja");
		},
		error: function (response) {
			getAlertSlideDown("⛌ Ajax: Nieudana operacja");
		}
	});

	
}


//UPDATE WHEN NETTO BRUTTO OR VAT VALUE HAS CHANGED
function updatePriceValues(sender)
{
	if (sender.name == "nettoAmountCol")
	{
		var nettoColValueArr = document.getElementsByName("nettoAmountCol");
		var bruttoColValueArr = document.getElementsByName("bruttoAmountCol");
		var vatColValueArr = document.getElementsByName("vatAmountCol");
		for (let i = 0; i < nettoColValueArr.length; i++)
		{
			bruttoColValueArr[i].value = (parseFloat(nettoColValueArr[i].value) * (parseFloat("1." + vatColValueArr[i].value))).toFixed(2);
        }
	}

	else if (sender.name == "bruttoAmountCol")
	{
		var nettoColValueArr = document.getElementsByName("nettoAmountCol");
		var bruttoColValueArr = document.getElementsByName("bruttoAmountCol");
		var vatColValueArr = document.getElementsByName("vatAmountCol");
		for (let i = 0; i < nettoColValueArr.length; i++) {
			nettoColValueArr[i].value = (parseFloat(bruttoColValueArr[i].value) / parseFloat("1." + vatColValueArr[i].value)).toFixed(2);
		}
	}

	else if (sender.name == "vatAmountCol")
	{
		var nettoColValueArr = document.getElementsByName("nettoAmountCol");
		var bruttoColValueArr = document.getElementsByName("bruttoAmountCol");
		var vatColValueArr = document.getElementsByName("vatAmountCol");

		for (let i = 0; i < nettoColValueArr.length; i++)
		{
			if (parseFloat(bruttoColValueArr[i].value))
				bruttoColValueArr[i].value = (parseFloat(nettoColValueArr[i].value) * parseFloat("1." + vatColValueArr[i].value)).toFixed(2);
			else if (parseFloat(nettoColValueArr[i].value))
				nettoColValueArr[i].value = (parseFloat(bruttoColValueArr[i].value) / parseFloat("1." + vatColValueArr[i].value)).toFixed(2);
		}
	}

}


//GETS THE CLASS OF ROW WHERE CLICKED
function getClassOfClickedRow(sender)
{
	var classAttr = sender.getAttribute('class');
	//alert(classAttr);
}


//UPDATES VAT VALUE WHEN IN FIRST ROW VALUE HAS CHANGED
function updateVatColumn()
{
	var arr = document.getElementsByName("vatAmountCol");
	for (let i = 1; i < arr.length; i++) {
		document.getElementsByName("vatAmountCol")[i].value = document.getElementsByName("vatAmountCol")[0].value;
	}
}


//SAUMMARY TO PAY
function getAmountToPay()
{
	var arr = document.getElementsByName("bruttoAmountCol");
	var arr2 = document.getElementsByName("vatAmountCol");
	var arr3 = document.getElementsByName("nettoAmountCol");
	var arr4 = document.getElementsByName("quantityCol");
	var total = 0;
	var totalVat = 0;
	for (var i = 0; i < arr.length; i++) {
		if (parseFloat(arr[i].value)) //&& parseInt(arr2[i].value)
		{
			total += parseFloat(arr[i].value) * parseFloat(arr4[i].value);
			totalVat += parseFloat(arr3[i].value) * parseFloat(arr2[0].value) * 0.01 * parseFloat(arr4[i].value);
		}
		document.getElementById("totalBruttoAmount").value = total.toFixed(2) + "zł";
		document.getElementById("totalVatAmount").value = totalVat.toFixed(2) + "zł";
	}

}


//AUTO RESIZE TEXTAREA
function auto_grow(sender)
{
	sender.style.height = (sender.scrollHeight) + "px";
}



// ONCLICK EDIT INVOICE STATUS // SENDS VALUE TO BACKEND WITHOUT SUBMIT/RELOAD
function editInvoice(rowNumber)
{
	$.ajax({
		type: "POST",
		url: "/Invoice/EditInvoice?handler=Edit",
		beforeSend: function (xhr) {
			xhr.setRequestHeader("XSRF-TOKEN",
				$('input:hidden[name="__RequestVerificationToken"]').val());
		},
		//data: { "name": $("#txtName").val() },
		data: { "selectedRow": rowNumber },

	});
}


//UserDataPage // display NewPassword window 
function displayChangePassWindow()
{
	document.getElementById("AccountUserDataModelDiV").classList.add("blur");
	document.getElementById("changePassWindow").style.visibility = "visible";
}


// CHANGE USER PASSWORD 
function saveNewPassWordBtnAction()
{
	if (changePassWindowPasswordIn.value == "" || changePassWindowPasswordIn2.value == "")
	{
		return;
    }

	else if (changePassWindowPasswordIn.value != changePassWindowPasswordIn2.value)
	{
		getAlertSlideDown("⛌ Hasła niezgodne");
		changePassWindowPasswordIn.value = "";
		changePassWindowPasswordIn2.value = "";
		return;
	}
	
	//SEND DATA TO BACKEND OnPostSaveNewPass
	$.ajax({
		type: "POST",
		url: "/Account/EditUserData?handler=SaveNewPass",
		beforeSend: function (xhr) {
			xhr.setRequestHeader("XSRF-TOKEN",
				$('input:hidden[name="__RequestVerificationToken"]').val());
		},
		data: { "newPass": $("#changePassWindowPasswordIn").val() },
		success: function (response) {
			getAlertSlideDown("✓ Powodzenie");
		},
		failure: function (response) {
			getAlertSlideDown("⛌ Ajax: Nieudana operacja");
		},
		error: function (response) {
			getAlertSlideDown("⛌ Ajax: Nieudana operacja");
		}
	});

	document.getElementById("AccountUserDataModelDiV").classList.remove("blur");
	document.getElementById("changePassWindow").style.visibility = "hidden";
	changePassWindowPasswordIn.value = "";
	changePassWindowPasswordIn2.value = "";

}


// CLOSE USER PASSWORD
function closeChangePassWindow()
{
	document.getElementById("AccountUserDataModelDiV").classList.remove("blur");
	document.getElementById("changePassWindow").style.visibility = "hidden";
	changePassWindowPasswordIn.value = "";
	changePassWindowPasswordIn2.value = "";
}


// SEARCH BY COLUMN 1-5
function searchCounterParty() {
	var searchInput, searchInputUpper, table, rowArr, column,
		column2, column3, column4, column5, txtValue;
	searchInput = document.getElementById("searchCounterPartyInput");
	searchInputUpper = searchInput.value.toUpperCase();
	table = document.getElementById("counterPartyTable");
	rowArr = table.getElementsByTagName("tr");
	columnsCount = table.rows[0].cells.length

	for (let i = 0; i < rowArr.length; i++) {
		column = rowArr[i].getElementsByTagName("td")[1];
		column2 = rowArr[i].getElementsByTagName("td")[2];
		column3 = rowArr[i].getElementsByTagName("td")[3];
		column4 = rowArr[i].getElementsByTagName("td")[4];
		column5 = rowArr[i].getElementsByTagName("td")[5];
		if (column || column2 || column3 || column4 || column5) {
			txtValue = (column.textContent || column.innerText) +
				(column2.textContent || column2.innerText) +
				(column3.textContent || column3.innerText) +
				(column4.textContent || column4.innerText) +
				(column5.textContent || column5.innerText);
			
			if (txtValue.toUpperCase().indexOf(searchInputUpper) > -1) {
				rowArr[i].style.display = "";
			} else {
				rowArr[i].style.display = "none";
			}
		}
	}
}


// SEARCH BY COLUMN 1-2,4-5
function searchInvoice() {
	var searchInput, searchInputUpper, table, rowArr, column,
		column2,  column4, column5, txtValue;
	searchInput = document.getElementById("searchInvoiceInput");
	searchInputUpper = searchInput.value.toUpperCase();
	table = document.getElementById("serviceProduktTable");
	rowArr = table.getElementsByTagName("tr");
	columnsCount = table.rows[0].cells.length

	for (let i = 0; i < rowArr.length; i++) {
		column = rowArr[i].getElementsByTagName("td")[1];
		column2 = rowArr[i].getElementsByTagName("td")[2];
		column4 = rowArr[i].getElementsByTagName("td")[4];
		column5 = rowArr[i].getElementsByTagName("td")[5];
		if (column || column2 || column4 || column5 ) {
			txtValue = (column.textContent || column.innerText) +
				(column2.textContent || column2.innerText) +
				(column4.textContent || column4.innerText) +
				(column5.textContent || column5.innerText);

			if (txtValue.toUpperCase().indexOf(searchInputUpper) > -1) {
				rowArr[i].style.display = "";
			} else {
				rowArr[i].style.display = "none";
			}
		}
	}
}







setTimeout(function ()
{
	$("#cat").fadeOut(550);
}
	, 1000);
