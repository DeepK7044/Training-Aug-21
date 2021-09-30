function checkDeatil(empName,Id,age,PhoneNo)
{
    var EmpName=empName.value
    var regexp=/^[0-9]{5}$/
    var id=Id.value
    if(regexp.test(id)==false)
    {
        alert("Please Enter Correct Employee Id");
        return;
    }

    if(age<1 || age>200)
    {
        alert("Please Enter Correct Phone number");
        return;
    }
    
    var PhoneNo=document.getElementById("PhoneNo").value
    if(PhoneNo.lenght<10)
    {
        alert("Please Enter Correct Phone number");
        return;
    }

    demoPage(EmpName)
}

function demoPage(EmpName)
{
    document.getElementById("Ename").innerHTML=EmpName;
}
