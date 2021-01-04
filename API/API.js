$(document).ready(function(){
	

var loadPage=function(){

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
					
					str1+="<tr><td>"+data[i].id+"</td><td>"+data[i].name+"</td><td>"+data[i].healthCard+"</td><td>"+data[i].hospitslId+"</td><td>"+data[i].dob+"</td><td>"+data[i].sex+"</td><td>"+data[i].bloodGroup+"</td><td>"+data[i].bornDisease+"</td><td>"+data[i].birthMark+"</td><td>"+data[i].phone+"</td><td>"+data[i].email+"</td><td><button>Update</button><button>Delete</button></td></tr>";
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



loadPage();

});