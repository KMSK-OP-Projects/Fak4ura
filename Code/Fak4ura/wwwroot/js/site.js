
// HIDE-SHOW lOGIN/REGISTER/RECOVER PAGE     ##################################LOGIN PAGE
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


	loginResult();

	recoveryResult();
 
});


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


//CREATES POPPINGUP ALERT 
function getAlert(msg, duration)
{
	var el = document.createElement("div");
	el.setAttribute("style", "position:absolute; text-align:center; top: 800px\
			;left: 50%;transform: translate(-50%, 0); background: rgba(43, 143, 173, 1)\
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
	el.setAttribute("style", "position:absolute; text-align:center; top: 0px\
			;left: 50%;transform: translate(-50%, 0); background: rgba(	0, 63, 122, 0.8)\
			;font-size:23px; color:white ; border-radius: 0px; padding:1px 15px 2px 15px;display:none;\
			;"); //box-shadow: 0px 3px 15px rgba(0,0,0,0.1);
	el.innerHTML = msg;
	document.body.appendChild(el);
	setTimeout(function ()
	{
		$("#ele").slideDown(300);
	}
		, 1000);

	setTimeout(function ()
	{
		$("#ele").slideUp(300);
	}
		, 4000);

}


//DISPLAY RESULT OF PASSWORD RECOVERY
function recoveryResult()
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
function loginResult() {
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


//ADDING IMAGE      ###############################USERDATA PAGE
function onFileSelected(event)
{
	var selectedFile = event.target.files[0];
	var reader = new FileReader();

	var imgElement = document.getElementById("myimage");
	imgElement.title = selectedFile.name;

	reader.onload = function (event)
	{
		imgElement.src = event.target.result;
	};

	reader.readAsDataURL(selectedFile);
	imgElement.src = "";
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
		+ amountOfRows + ' " type="text" value="' + amountOfRows + '."/>';
	cell = row.insertCell();
	cell.innerHTML = '<textarea class="form-control bg-lights serviceProduktInput productTableRow'
		+ amountOfRows + '" style="height:32px;overflow:hidden""></textarea>';
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
			bruttoColValueArr[i].value = parseFloat(nettoColValueArr[i].value) * (parseFloat("1." + vatColValueArr[i].value)).toFixed(2);
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


//GETS THE CLASS OF ROW WHERE INPUT HAS CHANGED
function getClassOfClickedRow(sender)
{
	var classAttr = sender.getAttribute('class');
	classes = classAttr.split(' ');
	for (let i = 0; i < classes.length; i++)
	{
		if (classes[i].includes("productTableRow"))
			classAttr = classes[i];
    }
	alert(classAttr);

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
		document.getElementById("totalBruttoAmount").value = total + "zł";
		document.getElementById("totalVatAmount").value = totalVat.toFixed(2) + "zł";
	}

}


//AUTO RESIZE TEXTAREA
function auto_grow(sender)
{
	sender.style.height = (sender.scrollHeight) + "px";
}








setTimeout(function ()
{
	$("#cat").fadeOut(550);
}
	, 1000);
