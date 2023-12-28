console.log("Hello!");
document.getElementById("btn-connect").addEventListener("click", (e) => {
    navigator.serial
    .requestPort()
    .then((port) => {
      console.log(port);
      var reader = port.readable.getReader();
      console.log(reader);
      debugger;
    })
    .catch((e) => {
      // The user didn't select a port.
    });
});