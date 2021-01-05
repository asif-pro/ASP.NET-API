function GetURLParameter(sParam)
{
    var sPageURL = window.location.search.substring(1);
    var sURLVariables = sPageURL.split('&');
    for (var i = 0; i < sURLVariables.length; i++) 
    {
        var sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] == sParam) 
        {
            return sParameterName[1];
        }
    }
}

$("#citizenBtn").click(function(){
	addCitizen();
});
$("#citizenUpdateBtn").click(function(){
	updateCitizen();
});

var addCitizen=function(){
	
	$.ajax({

		url:"http://localhost:51369/api/patients",
		method:"POST",
		headers:{
				Authorization:"Basic "+btoa("admin:123")
			},
		header:"Content-Type:application/json",
		data:{
			hospitalId:$("#hospitalID").val(),
			name:$("#citizenName").val(),
			sex:$("#gender option:selected").text(),
			dob:$("#citizenDOB").val(),
			healthCard:$("#healthCardID").val(),
			bloodGroup:$("#citizenBloodGroup option:selected").text(),
			bornDisease:$("#bornDiseases").val(),
			birthMark:$("#birthMark").val(),
			email:$("#email").val(),
			phone:$("#phone").val()	
		},
		complete:function(xmlhttp,status){
			if (xmlhttp.status==201) {

				/*$("#msgtag2").html("Citizen Added");*/
				window.location.href='all-citizens.html';

			}
			else
			{
				$("#msgtag2").html(xmlhttp.status+":"+xmlhttp.statusText);
			
			}
		}
	})
}




function deletePatient(id, name) {
	if(confirm("Are you sure to remove the patient "+name+" ?")) {
		$.ajax({
			url:"http://localhost:51369/api/patients/"+id,
			method:"DELETE",
			headers:{
				Authorization:"Basic "+btoa("admin:123")
			},
			success: function(response, xhr) {
				$("#allcitizens>tbody").html('');
				executeAllPatients();
				alert("Parient "+name+" Removed Successfully");
			},
			error: function(xhr, status, error) {
				
			}
		});
	}
}

function executeAllPatients() {
	$.ajax({
		url:"http://localhost:51369/api/patients",
		method:"GET",
		headers:{
			Authorization:"Basic "+btoa("admin:123")
		},
		complete:function(xmlhttp,status){

			if (xmlhttp.status==200) 
			{
				var data = xmlhttp.responseJSON;
				var str1 = '';

				for (var i = 0; i < data.length; i++) {
					
					str1+= "<tr>\
					<td>"+data[i].id+"</td>\
					<td>"+data[i].name+"</td>\
					<td>"+data[i].healthCard+"</td>\
					<td>"+data[i].hospitalId+"</td>\
					<td>"+data[i].dob.split("T")[0]+"</td>\
					<td>"+data[i].sex+"</td>\
					<td>"+data[i].bloodGroup+"</td>\
					<td>"+data[i].bornDisease+"</td>\
					<td>"+data[i].birthMark+"</td>\
					<td>"+data[i].phone+"</td>\
					<td>"+data[i].email+"</td>\
					<td><button class=\"btn-fill-lg btn-gradient-yellow btn-hover-bluedark\" onclick=\"window.location.href = 'update-citizen.html?id="+data[i].id+"'\">Update</button>\
					<button class=\"btn-fill-lg bg-blue-dark btn-hover-yellow\">BirthCertificate</button>\
					<button class=\"btn-fill-lg btn-gradient-yellow btn-hover-bluedark\" onclick=\"deletePatient("+data[i].id+", '"+data[i].name+"')\">Delete</button></td>\
					</tr>";
				}

				$("#allcitizens>tbody").html(str1);

			}
			else
			{
				$("#msgtag1").html(xmlhttp.status+":"+xmlhttp.statusText);
			}

			console.log(status);

		}
	});
}

function executeSinglePatient() {
	var patientId = GetURLParameter("id");

	if(patientId) {
		$.ajax({
			url:"http://localhost:51369/api/patients/"+patientId,
			method:"GET",
			headers:{
				Authorization:"Basic "+btoa("admin:123")
			},
			success: function(response, xhr) {
				$("#hospitalId").val(response.hospitalId);
				$("#citizenId").val(response.id);
				$("#name").val(response.name);
				$("#gender").val(response.sex).trigger('change');
				$("#dob").val(response.dob.split("T")[0]);
				$("#healthCard").val(response.healthCard);
				$("#bloodGroup").val(response.bloodGroup).trigger('change');
				$("#bornDiseases").val(response.bornDisease);
				$("#birthMark").val(response.birthMark);
				$("#eMail").val(response.email);
				$("#phone").val(response.phone);
			},
			error: function(xhr, status, error) {
				
			}
		});
	}
}

var updateCitizen=function(){
	
	$.ajax({

		url:"http://localhost:51369/api/patients/"+patientId,
		method:"PUT",
		header:"Content-Type:application/json",
		headers:{
				Authorization:"Basic "+btoa("admin:123")
			},
		data:{

			hospitalId:$("#hospitalId").val(),
			name:$("#name").val(),
			sex:$("#gender option:selected").text(),
			dob:$("#dob").val(),
			healthCard:$("#healthCard").val(),
			bloodGroup:$("#bloodGroup option:selected").text(),
			bornDisease:$("#bornDiseases").val(),
			birthMark:$("#birthMark").val(),
			email:$("#eMail").val(),
			phone:$("#phone").val()	
		},
		complete:function(xmlhttp,status){
			if (xmlhttp.status==200) {

				/*$("#msgtag2").html("Citizen Added");*/
				window.location.href='all-citizens.html';

			}
			else
			{
				$("#msgtag3").html(xmlhttp.status+":"+xmlhttp.statusText);
			
			}
		}
	})
}


function doValidation(){

	$("#hID").hide();
	$("#cName").hide();
	$("#dOB").hide();
	$("#hCIN").hide();
	$("#bG").hide();
	$("#bDiseases").hide();
	$("#bM").hide();
	$("#emailmsg").hide();
	$("#phoneerr").hide();
	$("#gendererr").hide();


	var err_hID = false;
	var err_cName = false;
	var err_dOB = false;
	var err_hCIN = false;
	var err_bG = false;
	var err_bDiseases = false;
	var err_bM = false;
	var err_emailmsg = false;
	var err_phoneerr = false;
	var err_gendererr = false;



	$("#hospitalID").focusout(function(){

		check_hospitalID();
	});

	$("#citizenName").focusout(function(){

		check_citizenName();
	});

	$("#gender").focusout(function(){

		check_gender();
	});

	$("#citizenDOB").focusout(function(){

		check_citizenDOB();
	});

	$("#healthCardID").focusout(function(){

		check_healthCardID();
	});

	$("#citizenBloodGroup").focusout(function(){

		check_citizenBloodGroup();
	});

	$("#bornDiseases").focusout(function(){

		check_bornDiseases();
	});

	$("#birthMark").focusout(function(){

		check_birthMark();
	});

	$("#email").focusout(function(){

		check_email();
	});

	$("#phone").focusout(function(){

		check_phone();
	});


/*function check_hospitalID(){

	
	var hID = $("#hospitalID").val();
	if ( hID !== ''){

		$("#hID").hide();
	}
	else{

		$("#hID").html("Can not be empty");
		$("#hID").show();
		var err_hID = true;
	}
}*/

function check_healthCardID(){

	
	var hCID = $("#healthCardID").val();
	if ( hCID !== ''){

		$("#hCIN").hide();
	}
	else{

		$("#hCIN").html("Can not be empty");
		$("#hCIN").show();
		var var err_hCIN = true;
	}
}

function check_citizenName(){

	var cNamePattern = /^[a-zA-z]*$/;
	var cName = $("#citizenName").val();
	if (cNamePattern.test(cName) && cName !== ''){

		$("#cName").hide();
	}
	else{

		$("#cName").html("Should contain only Alphabets");
		$("#cName").show();
		var err_cName = true;
	}
}

function check_bornDiseases(){

	
	var bonD = $("#bornDiseases").val();
	if ( bonD !== ''){

		$("#bDiseases").hide();
	}
	else{

		$("#bDiseases").html("Can not be empty");
		$("#bDiseases").show();
		var var err_bDiseases = true;
	}
}


function check_birthMark(){

	
	var biMark = $("#birthMark").val();
	if ( biMark !== ''){

		$("#bM").hide();
	}
	else{

		$("#bM").html("Can not be empty");
		$("#bM").show();
		 var err_bM = true;
	}
}

function check_email(){

	var cEmailPattern = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
	var cEmail = $("#email").val();
	if (cEmailPattern.test(cEmail) && cEmail !== ''){

		$("#emailmsg").hide();
	}
	else{

		$("#emailmsg").html("Should contain only Alphabets");
		$("#emailmsg").show();
		var err_emailmsg = true;
	}
}

function check_gender(){}
function check_citizenDOB(){}
function check_citizenBloodGroup(){}
function check_phone(){}

check_hospitalID();
check_citizenName();
check_gender();
check_citizenDOB();
check_healthCardID();
check_citizenBloodGroup();
check_bornDiseases();
check_birthMark();
check_email();
check_phone();

if(var err_hID === false && var err_cName === false && var err_dOB === false && var err_hCIN === false && var err_bG === false && var err_bDiseases === false && var err_bM === false && var err_emailmsg === false && var err_phoneerr === false && var err_gendererr === false && )
{

}
else
{
	alert("Please Fillup the from correctly");
}

});