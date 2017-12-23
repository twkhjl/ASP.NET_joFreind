
//format SQL server datetime data and return locale datetime format string
function getDateFormat(data)
{
    var myDate = new Date(data);

    //slice function is for deleteing seconds string
    var result = myDate.toLocaleDateString()+" "+myDate.toLocaleTimeString().slice(0,-3);
    return result;
}
