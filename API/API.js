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