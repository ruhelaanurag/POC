javascript: (function () {
  var element = document.createElement("script");
  var ele = window.location.href;
  alert(ele);
  document.location.href = "https://www.google.com/search?q=" + ele;
  //todo: replace this with external js and do javascript ajax call to post the current url to a lambda function.
  //todo: make a labda function that accepts the url and save it into xml/json file.
  //todo: build an azure webapp to display the list of urls with the date saved.
  //todo: bookmarks.anuragruhela.net
})();

javascript: (function () {
  var element = document.createElement("script");
  element.setAttribute(
    "src",
    "https://mraccess77.github.io/favlets/textSpacing.js"
  );
  document.body.appendChild(element);
})();
