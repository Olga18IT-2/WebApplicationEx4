function SelectAllBox(headerchek) {
    var ischecked = headerchek.checked;
    parent = document.getElementById('GridView1');
    var item = parent.getElementsByTagName('input');
    for (i=0; i<item.length; i++)
    {
        if (item[i].id != headerchek && item[i].type == "checkbox")
        {
            if (item[i].checked!=ischecked)
            { item[i].click();}
        }
    }
}