const tblBlog = "Blogs";
let blogId = null;

getBlogsTable();
//testConfirmMessage();

function readBlog() {
  const lst = getBlog();
  console.log(lst);
}

function editBlog(id) {
  const lst = getBlog();
  const items = lst.filter((x) => x.Id === id);
  console.log(items);
  console.log(items.length);

  if (items.length === 0) {
    console.log("no data found");
    errorMessage("No data found");
    return;
  }

  const item = items[0];
  blogId = item.Id;
  $("#txtTitle").val(item.Title);
  $("#txtAuthor").val(item.Author);
  $("#txtContent").val(item.Content);
  $("#txtTitle").focus();
}

function createBlog(title, author, content) {
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

function updateBlog(id, title, author, content) {
  const lst = getBlog();
  const items = lst.filter((x) => x.Id === id);
  console.log(items);
  console.log(items.length);

  if (items.length === 0) {
    console.log("no data found");
    errorMessage("No data found");
    return;
  }

  const item = items[0];
  item.Title = title;
  item.Author = author;
  item.Content = content;
  console.log(item);

  const index = lst.findIndex((x) => x.Id === id);
  console.log(index);
  lst[index] = item;
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);
  successMessage("Updating Successful");
}

function deleteBlog3(id) {
  let result = confirm("Are you sure want to delete?");
  console.log(result);
  if (!result) return;
  let lst = getBlog();
  const items = lst.filter((x) => x.Id === id);

  if (items.length === 0) {
    console.log("no data found");
    errorMessage("No data found");
    return;
  }

  lst = lst.filter((x) => x.Id !== id);
  const jsonBlog = JSON.stringify(lst);
  localStorage.setItem(tblBlog, jsonBlog);

  successMessage("Deleting successful");
  getBlogsTable();
}

function deleteBlog2(id) {
  Swal.fire({
    title: "Confirm",
    text: "Are you sure want to delete?",
    icon: "warning",
    showCancelButton: true,
    confirmButtonText: "Yes",
  }).then((result) => {
    if (!result.isConfirmed) return;
    let lst = getBlog();
    const items = lst.filter((x) => x.Id === id);

    if (items.length === 0) {
      console.log("no data found");
      errorMessage("No data found");
      return;
    }

    lst = lst.filter((x) => x.Id !== id);
    const jsonBlog = JSON.stringify(lst);
    localStorage.setItem(tblBlog, jsonBlog);

    successMessage("Deleting successful");
    getBlogsTable();
  });
} // sweetalert

function testConfirmMessage2(id) {
  let confirmMessage = new Promise(function (success, error) {
    // "Producing Code" (May take some time)
    const result = confirm("Are you sure want to delete?");
    if (result) {
      success(); // when successful
    } else {
      error(); // when error
    }
  });

  // "Consuming Code" (Must wait for a fulfilled Promise)
  confirmMessage.then(
    function (value) {
      /* code if successful */
      successMessage("Success");
    },
    function (error) {
      /* code if some error */
      errorMessage("Error");
    }
  );
}

function testConfirmMessage(id) {
  let confirmMessage = new Promise(function (success, error) {
    Swal.fire({
      title: "Confirm",
      text: "Are you sure want to delete?",
      icon: "warning",
      showCancelButton: true,
      confirmButtonText: "Yes",
    }).then((result) => {
      if (result.isConfirmed) {
        success();
      } else error();
    });
  });
  confirmMessage.then(
    function (value) {
      /* code if successful */
      successMessage("Success");
    },
    function (error) {
      /* code if some error */
      errorMessage("Error");
    }
  );
}

function deleteBlog(id) {
  confirmMessage("Are you sure want to delete?").then(
    function (value) {
      /* code if successful */
      let lst = getBlog();

      const items = lst.filter((x) => x.Id === id);
      if (items.length === 0) {
        console.log("no data found");
        return;
      }

      lst = lst.filter((x) => x.Id !== id);
      const jsonBlog = JSON.stringify(lst);
      localStorage.setItem(tblBlog, jsonBlog);

      successMessage("Deleting successful");
      getBlogsTable();
    }
  );
}

function getBlog() {
  const blog = localStorage.getItem(tblBlog);
  console.log(blog);
  let lst = [];
  if (blog !== null) {
    lst = JSON.parse(blog);
  }
  return lst;
}

function getBlogsTable() {
  const lst = getBlog();
  let htmlRows = "";
  let count = 0;
  lst.forEach((item) => {
    const htmlRow = `<tr>
                <th>
                <button type="button" class="btn btn-warning" onclick = "editBlog('${
                  item.Id
                }')">Edit</button>
                <button type="button" class="btn btn-danger" onclick = "deleteBlog('${
                  item.Id
                }')">Delete</button>
                </th>
                <th>${++count}</th>
                <th>${item.Title}</th>
                <th>${item.Author}</th>
                <th>${item.Content}</th>
            </tr>`;
    htmlRows += htmlRow;
  });
  $("#tbody").html(htmlRows);
}

$("#btnSave").click(function () {
  const title = $("#txtTitle").val();
  const author = $("#txtAuthor").val();
  const content = $("#txtContent").val();

  if (blogId === null) {
    createBlog(title, author, content);
  } else {
    updateBlog(blogId, title, author, content);
  }
  getBlogsTable();
});

$("#btnCancel").click(function () {
  deleteBlog(blogId);
});

function clearControls() {
  $("#txtTitle").val("");
  $("#txtAuthor").val("");
  $("#txtContent").val("");
  $("#txtTitle").focus();
}
