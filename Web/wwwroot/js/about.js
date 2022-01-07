$(document).ready(function () {



    const selectedFile = document.getElementById('attachment')
        fileList = document.getElementById("fileList");
    selectedFile.addEventListener("change", handleFiles, false);
    function handleFiles() {
        debugger
        if (!this.files.length) {
            fileList.innerHTML = "<p>No files selected!</p>";
        } else {
            fileList.innerHTML = "";
            const list = document.createElement("ul");
            fileList.appendChild(list);
            for (let i = 0; i < this.files.length; i++) {
                const li = document.createElement("li");
                li.appendChild(document.createTextNode(this.files[i].name))
                list.appendChild(li);
            }
        }
    }

    
})