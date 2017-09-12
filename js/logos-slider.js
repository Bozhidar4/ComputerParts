$(function () {
  var $first=$('#scroller>:first-child');
  $('#scroller').width($first.outerWidth(true));
  $first.clone(true).appendTo('#scroller');
  $('#scroller').addClass('ready');
 })