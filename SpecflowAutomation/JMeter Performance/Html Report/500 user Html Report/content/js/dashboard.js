/*
   Licensed to the Apache Software Foundation (ASF) under one or more
   contributor license agreements.  See the NOTICE file distributed with
   this work for additional information regarding copyright ownership.
   The ASF licenses this file to You under the Apache License, Version 2.0
   (the "License"); you may not use this file except in compliance with
   the License.  You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/
var showControllersOnly = false;
var seriesFilter = "";
var filtersOnlySampleSeries = true;

/*
 * Add header in statistics table to group metrics by category
 * format
 *
 */
function summaryTableHeader(header) {
    var newRow = header.insertRow(-1);
    newRow.className = "tablesorter-no-sort";
    var cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Requests";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 3;
    cell.innerHTML = "Executions";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 7;
    cell.innerHTML = "Response Times (ms)";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 1;
    cell.innerHTML = "Throughput";
    newRow.appendChild(cell);

    cell = document.createElement('th');
    cell.setAttribute("data-sorter", false);
    cell.colSpan = 2;
    cell.innerHTML = "Network (KB/sec)";
    newRow.appendChild(cell);
}

/*
 * Populates the table identified by id parameter with the specified data and
 * format
 *
 */
function createTable(table, info, formatter, defaultSorts, seriesIndex, headerCreator) {
    var tableRef = table[0];

    // Create header and populate it with data.titles array
    var header = tableRef.createTHead();

    // Call callback is available
    if(headerCreator) {
        headerCreator(header);
    }

    var newRow = header.insertRow(-1);
    for (var index = 0; index < info.titles.length; index++) {
        var cell = document.createElement('th');
        cell.innerHTML = info.titles[index];
        newRow.appendChild(cell);
    }

    var tBody;

    // Create overall body if defined
    if(info.overall){
        tBody = document.createElement('tbody');
        tBody.className = "tablesorter-no-sort";
        tableRef.appendChild(tBody);
        var newRow = tBody.insertRow(-1);
        var data = info.overall.data;
        for(var index=0;index < data.length; index++){
            var cell = newRow.insertCell(-1);
            cell.innerHTML = formatter ? formatter(index, data[index]): data[index];
        }
    }

    // Create regular body
    tBody = document.createElement('tbody');
    tableRef.appendChild(tBody);

    var regexp;
    if(seriesFilter) {
        regexp = new RegExp(seriesFilter, 'i');
    }
    // Populate body with data.items array
    for(var index=0; index < info.items.length; index++){
        var item = info.items[index];
        if((!regexp || filtersOnlySampleSeries && !info.supportsControllersDiscrimination || regexp.test(item.data[seriesIndex]))
                &&
                (!showControllersOnly || !info.supportsControllersDiscrimination || item.isController)){
            if(item.data.length > 0) {
                var newRow = tBody.insertRow(-1);
                for(var col=0; col < item.data.length; col++){
                    var cell = newRow.insertCell(-1);
                    cell.innerHTML = formatter ? formatter(col, item.data[col]) : item.data[col];
                }
            }
        }
    }

    // Add support of columns sort
    table.tablesorter({sortList : defaultSorts});
}

$(document).ready(function() {

    // Customize table sorter default options
    $.extend( $.tablesorter.defaults, {
        theme: 'blue',
        cssInfoBlock: "tablesorter-no-sort",
        widthFixed: true,
        widgets: ['zebra']
    });

    var data = {"OkPercent": 99.08, "KoPercent": 0.92};
    var dataset = [
        {
            "label" : "FAIL",
            "data" : data.KoPercent,
            "color" : "#FF6347"
        },
        {
            "label" : "PASS",
            "data" : data.OkPercent,
            "color" : "#9ACD32"
        }];
    $.plot($("#flot-requests-summary"), dataset, {
        series : {
            pie : {
                show : true,
                radius : 1,
                label : {
                    show : true,
                    radius : 3 / 4,
                    formatter : function(label, series) {
                        return '<div style="font-size:8pt;text-align:center;padding:2px;color:white;">'
                            + label
                            + '<br/>'
                            + Math.round10(series.percent, -2)
                            + '%</div>';
                    },
                    background : {
                        opacity : 0.5,
                        color : '#000'
                    }
                }
            }
        },
        legend : {
            show : true
        }
    });

    // Creates APDEX table
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.9658, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Signout"], "isController": false}, {"data": [1.0, 500, 1500, "Share Skill Add"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Add Educatiom"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.5, 500, 1500, "Categories"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Manage Listing"], "isController": false}, {"data": [0.816, 500, 1500, "Update Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "View Manage listing"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Toggle Checkbox"], "isController": false}]}, function(index, item){
        switch(index){
            case 0:
                item = item.toFixed(3);
                break;
            case 1:
            case 2:
                item = formatDuration(item);
                break;
        }
        return item;
    }, [[0, 0]], 3);

    // Create statistics table
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 10000, 92, 0.92, 142.97789999999995, 1, 922, 119.0, 197.0, 790.6499999994248, 862.0, 23.64010307084939, 11.317593149393632, 15.698090396799131], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Signout", 500, 0, 0.0, 42.28199999999999, 36, 65, 42.0, 45.0, 46.0, 54.99000000000001, 1.1903146477739925, 0.23480816293979148, 0.6288674066852832], "isController": false}, {"data": ["Share Skill Add", 500, 0, 0.0, 81.96999999999989, 74, 103, 81.0, 88.0, 90.0, 96.99000000000001, 1.190311814082817, 0.26038070933061624, 1.949368078336801], "isController": false}, {"data": ["Update Skills", 500, 0, 0.0, 167.1219999999999, 147, 214, 167.0, 177.0, 181.0, 189.99, 1.1900766647387426, 0.24057213828214813, 0.7693543469632813], "isController": false}, {"data": ["Add Educatiom", 500, 0, 0.0, 141.86000000000013, 111, 194, 148.0, 165.0, 168.0, 176.97000000000003, 1.1901673137209627, 0.24140870286044813, 0.8213525946540065], "isController": false}, {"data": ["Delete Education", 500, 0, 0.0, 41.73999999999998, 1, 78, 43.0, 46.0, 48.94999999999999, 60.98000000000002, 1.1904251722545225, 0.25352336090358035, 0.6943712828973997], "isController": false}, {"data": ["Categories", 500, 0, 0.0, 848.1079999999998, 817, 922, 843.0, 877.9000000000001, 886.0, 899.0, 1.188057644556914, 6.279070285490252, 0.8620379198298701], "isController": false}, {"data": ["Add Description", 500, 0, 0.0, 126.97400000000003, 110, 166, 127.0, 135.0, 138.0, 147.98000000000002, 1.190164480731237, 0.2556994001571017, 0.7159583204398847], "isController": false}, {"data": ["Delete Skills", 500, 0, 0.0, 43.286000000000016, 38, 67, 44.0, 46.0, 47.0, 53.950000000000045, 1.1904705215689448, 0.22243895192760987, 0.7719341031411755], "isController": false}, {"data": ["Delete Language Request", 500, 0, 0.0, 43.018, 37, 80, 43.0, 45.0, 46.0, 50.0, 1.1904705215689448, 0.2328881209196623, 0.6940536146256446], "isController": false}, {"data": ["Delete Manage Listing", 500, 0, 0.0, 163.27999999999997, 149, 199, 162.0, 174.0, 177.0, 184.99, 1.1900030226076774, 0.2196392297586436, 0.6972673960591861], "isController": false}, {"data": ["Update Certifications", 500, 92, 18.4, 191.48999999999972, 113, 260, 204.0, 215.0, 217.95, 225.99, 1.1899407171534713, 0.18967469103189277, 0.8202851685491528], "isController": false}, {"data": ["Update Education", 500, 0, 0.0, 171.3820000000001, 1, 290, 168.0, 207.0, 214.0, 272.94000000000005, 1.189986029564013, 0.2583943102007982, 0.868810659537857], "isController": false}, {"data": ["Add Language", 500, 0, 0.0, 46.59800000000003, 41, 65, 46.0, 50.0, 51.0, 61.0, 1.1903968306874781, 0.2406368593284257, 0.701785431566467], "isController": false}, {"data": ["Add Certifications", 500, 0, 0.0, 84.32200000000002, 78, 115, 84.0, 88.0, 89.0, 95.99000000000001, 1.1903004794530332, 0.2406173820769315, 0.773579071363275], "isController": false}, {"data": ["View Manage listing", 500, 0, 0.0, 125.17599999999993, 109, 158, 125.0, 133.0, 135.0, 144.0, 1.1901814788718983, 0.4951340917963171, 0.726429125288024], "isController": false}, {"data": ["Add Skills", 500, 0, 0.0, 45.186, 39, 80, 45.0, 48.0, 50.0, 62.97000000000003, 1.1904733560158192, 0.24065232880397905, 0.739404861536044], "isController": false}, {"data": ["Delete Certifications", 500, 0, 0.0, 43.40600000000001, 37, 98, 43.0, 46.0, 47.0, 59.0, 1.1903996647834545, 0.23679188331940568, 0.6998248029293355], "isController": false}, {"data": ["SignIn", 500, 0, 0.0, 164.9759999999999, 154, 217, 164.0, 173.0, 178.95, 192.0, 1.1900228484386899, 0.5717687904607768, 0.4113946175266565], "isController": false}, {"data": ["Update Language", 500, 0, 0.0, 167.49400000000009, 148, 207, 168.0, 177.0, 180.95, 190.98000000000002, 1.1900908277319726, 0.24987258590075592, 0.7600449988218101], "isController": false}, {"data": ["Toggle Checkbox", 500, 0, 0.0, 119.88799999999992, 108, 165, 118.0, 128.0, 133.0, 143.98000000000002, 1.1901446501807829, 0.22082762063901246, 0.6996748822351868], "isController": false}]}, function(index, item){
        switch(index){
            // Errors pct
            case 3:
                item = item.toFixed(2) + '%';
                break;
            // Mean
            case 4:
            // Mean
            case 7:
            // Median
            case 8:
            // Percentile 1
            case 9:
            // Percentile 2
            case 10:
            // Percentile 3
            case 11:
            // Throughput
            case 12:
            // Kbytes/s
            case 13:
            // Sent Kbytes/s
                item = item.toFixed(2);
                break;
        }
        return item;
    }, [[0, 0]], 0, summaryTableHeader);

    // Create error table
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 92, 100.0, 0.92], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 10000, 92, "500/Internal Server Error", 92, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certifications", 500, 92, "500/Internal Server Error", 92, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
