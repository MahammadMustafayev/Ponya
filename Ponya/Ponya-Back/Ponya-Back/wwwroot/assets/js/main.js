let d = document.querySelectorAll(".d");
let fg = document.querySelectorAll(".fg");

d.forEach(x => {
    x.addEventListener("click", function () {
        fg.forEach(b => {
            b.classList.add("d-none");
            if (x.getAttribute("data-target") == "all") {
                b.classList.remove("d-none");
            }
            else if (x.getAttribute("data-target") == b.getAttribute("data-id")) {
                b.classList.remove("d-none");
            }
        })
    })
})