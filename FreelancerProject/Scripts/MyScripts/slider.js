$("#slider").slider({
    min: 1,
    max: 5,
    range: "max",
    value: 5,
    change: function (event, ui) {
        $("#value").text($("#slider").slider("value"));
        $("#LowestRankToFilter").val($("#slider").slider("value"));
    }
});