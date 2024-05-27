function ChartGenerated(chartName, XLabels, YValues, type)
{
   
        var ctx = document.getElementById(chartName).getContext('2d');
        var data = {
            labels: XLabels,
        datasets: [{
            label: "Sales Analysis",
            backgroundColor: [
                'rgba(255, 99, 132, 0.2)',
                'rgba(54, 162, 235, 0.2)',
                'rgba(255, 206, 86, 0.2)',
                'rgba(75, 192, 192, 0.2)',
                'rgba(153, 102, 255, 0.2)',
                'rgba(255, 159, 64, 0.2)',
                'rgba(220, 221, 176,0.8)',
                'rgba(221, 198, 176,0.8)',
                'rgba(163, 172, 201,0.8)',
                'rgba(241, 198, 198,0.5)',
                'rgba(242, 200, 164,0.5)',
                'rgba(178, 204, 255,0.55)'
            ],
            borderColor: [
                'rgba(255,99,132,1)',
                'rgba(54, 162, 235, 1)',
                'rgba(255, 206, 86, 1)',
                'rgba(75, 192, 192, 1)',
                'rgba(153, 102, 255, 1)',
                'rgba(255, 159, 64, 1)',
                'rgba(220, 221, 176,0.8)',
                'rgba(221, 198, 176,0.8)',
                'rgba(163, 172, 201,0.8)',
                'rgba(241, 198, 198,0.5)',
                'rgba(242, 200, 164,0.5)',
                'rgba(178, 204, 255,0.55)'
            ],
            borderWidth: 1,
            data: YValues
    }]
        };

    var options = {
        maintainAspectRatio: false,
        scales: {
            yAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: true,
                    color: "rgba(255,99,164,0.2)"
                }
            }],
            xAxes: [{
                ticks: {
                    min: 0,
                    beginAtZero: true
                },
                gridLines: {
                    display: false
                }
            }]
        }
    };
    
    var myChart = new Chart(ctx, {
        options: options,
        data: data,
        type: type
    
    });
     
}