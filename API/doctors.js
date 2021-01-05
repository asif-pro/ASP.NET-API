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


$("#addDoctorBtn").click(function(){
	addDoctor();
});



function executeAllDoctors() { 
	$.ajax({
		url:"http://localhost:51369/api/doctors",
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
					<td>"+data[i].hospitalId+"</td>\
					<td>"+data[i].speciality+"</td>\
					<td>"+data[i].degree+"</td>\ </tr>";
					
					
				}

				$("#allDoctors>tbody").html(str1);

			}
			else
			{
				//$("#msgtag1").html(xmlhttp.status+":"+xmlhttp.statusText);
			}

			console.log(status);

		}
	});
}


var addDoctor=function(){
	
	$.ajax({

		url:"http://localhost:51369/api/doctors",
		method:"POST",
		headers:{
				Authorization:"Basic "+btoa("admin:123")
			},
		header:"Content-Type:application/json",
		data:{

			name:$("#dName").val(),
			hospitalId:$("#dHID").val(),
			speciality:$("#dSpeciality").val(),
			degree:$("#dDegree").val()

		},
		complete:function(xmlhttp,status){
			if (xmlhttp.status==201) {

				/*$("#msgtag2").html("Doctor Added");*/
				window.location.href='all-doctors.html';

			}
			else
			{
				// $("#msgtag2").html(xmlhttp.status+":"+xmlhttp.statusText);
			
			}
		}
	})
}


