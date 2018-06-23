$(document).ready(function(){  
    $('#btnUpload').click(function () {  
  
        // Checking whether FormData is available in browser  
        if (window.FormData !== undefined) {  
            console.log(window.FormData);
            var fileUpload = $("#file").get(0);  
            var files = fileUpload.files;  
            console.log(files);
            // Create FormData object  
            var fileData = new FormData();  
  
            // Looping over all files and add it to FormData object  
            for (var i = 0; i < files.length; i++) {  
                fileData.append(files[i].name, files[i]);  
            }  
            console.log(fileData);
            // Adding one more key to FormData object  
            fileData.append('name', 'aaaa');

            $.ajax({  
                url: '/Artist/CreateTes',
                type: "POST",
                contentType: false, // Not to set any content header  
                processData: false, // Not to process data  
                data: fileData,  
                success: function (result) {  
                    alert(result);  
                },  
                error: function (err) {  
                    alert(err.statusText);  
                }  
            });  
        } else {  
            alert("FormData is not supported.");  
        }  
    });  
});  
