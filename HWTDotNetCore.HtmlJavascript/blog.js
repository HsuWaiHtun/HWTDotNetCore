const tblBlog = "Blogs";
let blogId = null;

getBlogsTable();

function readBlog(){
    const lst = getBlog();
    console.log(lst);
}

function editBlog(id){
    const lst = getBlog();
    const items = lst.filter(x=> x.Id === id);
    console.log(items);
    console.log(items.length);
    
    if(items.length === 0){
        console.log("no data found");
        errorMessage("No data found");
        return;
    }

    const item = items[0];
    blogId = item.Id;
    $('#txtTitle').val(item.Title);
    $('#txtAuthor').val(item.Author);
    $('#txtContent').val(item.Content);
    $('#txtTitle').focus();
}

function createBlog(title, author, content){
    const lst = getBlog();
    const requestModel = {
        Id: uuidv4(),
        Title: title,
        Author: author,
        Content: content,
    };
    lst.push(requestModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    successMessage("Saving successful");
    clearControls();
    getBlogsTable();
}

function updateBlog(id, title, author, content){
    const lst = getBlog();
    const items = lst.filter(x=> x.Id === id);
    console.log(items);
    console.log(items.length);
    
    if(items.length === 0){
        console.log("no data found");
        return;
    }

    const item = items[0];
    item.Title = title;
    item.Author = author;
    item.Content = content;
    console.log(item);

    const index = lst.findIndex(x=> x.Id === id);
    console.log(index);
    lst[index] = item;
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    successMessage("Updating Successful");
}

function deleteBlog(id){
    let result = confirm("Are you sure want to delete?");
    console.log(result);
    if(!result) return;
    let lst = getBlog();
    const items = lst.filter(x=> x.Id === id);
    
    if(items.length === 0){
        console.log("no data found");
        return;
    }

    lst = lst.filter(x=> x.Id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
    
    successMessage("Deleting successful");
    getBlogsTable();
}

function getBlog(){
    const blog = localStorage.getItem(tblBlog);
    console.log(blog);
    let lst = [];
    if(blog !== null){
        lst = JSON.parse(blog);
    }
    return lst;
}

function getBlogsTable(){
    const lst = getBlog();
    let htmlRows = '';
    let count = 0;
    lst.forEach(item => {
        const htmlRow = 
            `<tr>
                <th>
                <button type="button" class="btn btn-warning" onclick = "editBlog('${item.Id}')">Edit</button>
                <button type="button" class="btn btn-danger" onclick = "deleteBlog('${item.Id}')">Delete</button>
                </th>
                <th>${++count}</th>
                <th>${item.Title}</th>
                <th>${item.Author}</th>
                <th>${item.Content}</th>
            </tr>`;
        htmlRows += htmlRow;
    });
    $('#tbody').html(htmlRows);
}

$('#btnSave').click(function(){
    const title = $('#txtTitle').val();
    const author = $('#txtAuthor').val();
    const content = $('#txtContent').val();
    alert(blogId);

    if(blogId === null){
        createBlog(title,author,content);
    }
    else {
        updateBlog(blogId,title,author,content);
    }
    getBlogsTable();
})

$('#btnCancel').click(function(){
    deleteBlog(blogId);
})
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function successMessage(message){
    Swal.fire({
        title: "Success!",
        text: message,
        icon: "success"
    });
}

function errorMessage(message){
    Swal.fire({
        title: "Success!",
        text: message,
        icon: "success"
    });
}

function clearControls(){
    $('#txtTitle').val('');
    $('#txtAuthor').val('');
    $('#txtContent').val('');
    $('#txtTitle').focus();
}