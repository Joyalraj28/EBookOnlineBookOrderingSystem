$(function () {
    var chartName = "chartStacked";
    var ctx = document.getElementById(chartName).getContext('2d');
    var XLabels = @Html.Raw(XLabels);
    var YValues = @Html.Raw(YValues);
    var label = @Html.Raw(label2);
    var aux = 0;
    var barChartData = {
        labels: @Html.Raw(label2),
        datasets: []
    }
    XLabels.forEach(function (a, i) {
        var data = [];
        YValues.forEach(function (a, i) {
            data.push(a[aux]);
        });
        barChartData.datasets.push({
            label: XLabels[aux],
            backgroundColor: random_rgba(),
            data: data
        });
        aux++;
    });
    var options = {
        maintainAspectRatio: false,
        scales: {
            yAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                stacked: true,
                gridLines: {
                    display: true,
                    color: "rgba(255,99,164,0.2)"
                }
            }],
            xAxes: [{
                stacked: true,
                gridLines: {
                    display: false
                }
            }]
        }
    };

    function random_rgba() {
        var o = Math.round,
            r = Math.random,
            s = 255;
        return 'rgba(' + o(r() * s) + ',' + o(r() * s) + ',' + o(r() * s) + ',' + r().toFixed(1) + ')';
    }
    var myChart = new Chart(ctx, {
        options: options,
        data: barChartData,
        type: 'bar'
    });
});