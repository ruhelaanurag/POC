javascript: (function () {
   const sParam = new URL(window.location).searchParams;
   const v = sParam.get('v');
   const lst = sParam.get('list');
   let rst = '';
   if (lst) {
      rst = '/videoseries?list=' + lst
   }
   window.location = 'https://www.youtube-nocookie.com/embed/' + sParam.get('v') + rst;
})();

/*javascript:(function(){const sParam=new URL(window.location).searchParams;const v=sParam.get('v');const lst=sParam.get('list');let rst='';if(lst){rst='/videoseries?list='+lst}window.location='https://www.youtube-nocookie.com/embed/'+sParam.get('v')+rst;})();*/
