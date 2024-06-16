const tblBlog = "Blogs";
//createBlog();
//updateBlog("37eaeb80-1d6c-44bc-8970-5b1462481927", "hello", "hello", "hello");
deleteBlog("2cbf3f41-10eb-43ea-898e-c969ad3ff3b4");

function readBlog(){
    const blog = localStorage.getItem(tblBlog);
    console.log(blog);
}

function createBlog(){
    const blog = localStorage.getItem(tblBlog);
    console.log(blog);
    let lst = [];
    if(blog !== null){
        lst = JSON.parse(blog);
    }
    const requestModel = {
        Id: uuidv4(),
        Title: "Test Title",
        Author: "Test Author",
        Content: "TestContent",
    };
    lst.push(requestModel);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (+c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> +c / 4).toString(16)
    );
}

function updateBlog(id, title, author, content){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }
    
    const items = lst.filter(x=> x.Id === id);
    console.log(items);
    console.log(items.length);
    
    if(items.length === 0){
        console.log("no data found");
        return;
    }

    const item = items[0];
    item.title = title;
    item.author = author;
    item.content = content;
    console.log(item);

    const index = lst.findIndex(x=> x.Id === id);
    console.log(index);
    lst[index] = item;
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}

function deleteBlog(id){
    const blogs = localStorage.getItem(tblBlog);
    console.log(blogs);

    let lst = [];
    if(blogs !== null){
        lst = JSON.parse(blogs);
    }
    
    const items = lst.filter(x=> x.Id === id);
    
    if(items.length === 0){
        console.log("no data found");
        return;
    }

    lst = lst.filter(x=> x.Id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);
}