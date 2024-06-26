const tblPhone = "Phones";
let num = 0;
let sum = 0;
let phoneId = null;

displayVoucherTable();

function count() {
  num += 1;
  return num;
}
function totalAmount(price) {
  sum += price;
  return sum;
}

function displayVoucher() {
  const phone = localStorage.getItem(tblPhone);
  let lst = [];
  if (phone !== null) {
    lst = JSON.parse(phone); //Convert to C#
  }
  return lst;
}

function displayVoucherTable() {
  const lst = displayVoucher();
  let htmlRows = "";
  let id = 0;
  lst.forEach((item) => {
    const htmlRow = `<tr>
                  <th>
                  <button type="button" class="btn btn-danger" onclick = "CancelOrder('${
                    item.Id
                  }')">Cancel</button>
                  </th>
                  <th>${++id}</th>
                  <th>${item.Type}</th>
                  <th>${item.Price}</th>
                  <th>${item.Quantity}</th>
                  <th>${item.TotalAmount}
              </tr>`;
    htmlRows += htmlRow;
  });
  $("#tbody").html(htmlRows);
}
function createVoucher(type, price, quantity, totalAmount) {
  let lst = displayVoucher();
  const buyItem = {
    Id: uuidv4(),
    Type: type,
    Price: price,
    Quantity: quantity,
    TotalAmount: totalAmount,
  };
  lst.push(buyItem);
  const jsonPhone = JSON.stringify(lst);
  localStorage.setItem(tblPhone, jsonPhone);
  displayVoucherTable();
}

function CancelOrder(id) {
  let result = confirm("Are you sure want to delete?");
  console.log(result);
  if (!result) return;
  let lst = displayVoucher();
  const items = lst.filter((x) => x.Id === id);

  if (items.length === 0) {
    console.log("no data found");
    return;
  }

  lst = lst.filter((x) => x.Id !== id);
  const jsonPhone = JSON.stringify(lst);
  localStorage.setItem(tblPhone, jsonPhone);
  displayVoucherTable();
}

$("#btn15").click(function () {
  let decreaseInstock = parseInt($("#quan1").text()) - 1;
  $("#quan1").text(decreaseInstock.toString());
  let qu = count();
  const type = $("#txt15").text();
  const price = parseInt($("#price15").text());
  let quantity = qu;
  let amount = totalAmount(price);
  createVoucher(type, price, quantity, amount);
  displayVoucherTable();
});

$("#btn25").click(function () {
  let decreaseInstock = parseInt($("#quan2").text()) - 1;
  $("#quan2").text(decreaseInstock.toString());
  let qu = count();
  const type = $("#txt25").text();
  const price = parseInt($("#price25").text());
  let quantity = qu;
  let amount = totalAmount(price);
  createVoucher(type, price, quantity, amount);
  displayVoucherTable();
});

$("#btn55").click(function () {
  let decreaseInstock = parseInt($("#quan3").text()) - 1;
  $("#quan3").text(decreaseInstock.toString());
  let qu = count();
  const type = $("#txt55").text();
  const price = parseInt($("#price55").text());
  let quantity = qu;
  let amount = totalAmount(price);
  createVoucher(type, price, quantity, amount);
  displayVoucherTable();
});