$(document).ready(function () {
    $('#Emprestimos').DataTable();
})

setTimeout(() => {
    $(".alert").fadeOut("slow", function () {
        $(this).alert('close');
    })
}, 5000);