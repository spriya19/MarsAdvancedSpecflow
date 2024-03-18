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

    var data = {"OkPercent": 99.3, "KoPercent": 0.7};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.968, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Signout"], "isController": false}, {"data": [1.0, 500, 1500, "Share Skill Add"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Add Educatiom"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.5, 500, 1500, "Categories"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Manage Listing"], "isController": false}, {"data": [0.86, 500, 1500, "Update Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [1.0, 500, 1500, "Add Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "View Manage listing"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Toggle Checkbox"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 4000, 28, 0.7, 137.20075000000048, 2, 1230, 111.0, 191.9000000000001, 763.4999999999472, 846.0, 21.875136719604498, 10.473143612665158, 14.527237706856763], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Signout", 200, 0, 0.0, 41.20000000000001, 36, 144, 40.0, 42.0, 44.94999999999999, 116.61000000000035, 1.1107593706437406, 0.21911464147464416, 0.5868367378108044], "isController": false}, {"data": ["Share Skill Add", 200, 0, 0.0, 79.6500000000001, 66, 148, 79.0, 84.9, 88.94999999999999, 139.95000000000005, 1.11043867880006, 0.2429084609875131, 1.8185602190895513], "isController": false}, {"data": ["Update Skills", 200, 0, 0.0, 163.465, 146, 364, 158.0, 169.0, 175.84999999999997, 328.60000000000036, 1.1096377587536548, 0.22431153912305327, 0.7172442735756412], "isController": false}, {"data": ["Add Educatiom", 200, 0, 0.0, 94.86500000000005, 75, 238, 82.0, 118.9, 124.89999999999998, 201.60000000000036, 1.1101982814130604, 0.22442484790283546, 0.7662211244365744], "isController": false}, {"data": ["Delete Education", 200, 0, 0.0, 41.82, 36, 125, 40.0, 43.900000000000006, 47.94999999999999, 100.97000000000003, 1.110679180318765, 0.23645318487254957, 0.6486192869439663], "isController": false}, {"data": ["Categories", 200, 0, 0.0, 839.3499999999998, 778, 1230, 833.0, 852.0, 877.8499999999999, 1157.6300000000003, 1.1056443142241141, 5.843502957598541, 0.8022399662778484], "isController": false}, {"data": ["Add Description", 200, 0, 0.0, 125.54000000000002, 110, 480, 120.0, 130.0, 170.44999999999965, 254.87000000000012, 1.1102352588513504, 0.23852710639384486, 0.6678758979027656], "isController": false}, {"data": ["Delete Skills", 200, 0, 0.0, 43.029999999999994, 37, 148, 41.0, 44.0, 50.94999999999999, 134.5500000000004, 1.110407852804335, 0.20738818539924714, 0.719910809959248], "isController": false}, {"data": ["Delete Language Request", 200, 0, 0.0, 42.425, 37, 125, 40.0, 44.0, 51.849999999999966, 100.86000000000013, 1.1102968933892923, 0.21710424508138476, 0.647311763040437], "isController": false}, {"data": ["Delete Manage Listing", 200, 0, 0.0, 159.62499999999991, 133, 409, 156.5, 168.0, 180.89999999999998, 329.60000000000036, 1.109865595276412, 0.2048482397531659, 0.6503118722322727], "isController": false}, {"data": ["Update Certifications", 200, 28, 14.0, 189.64000000000007, 114, 378, 193.0, 209.9, 235.79999999999995, 369.52000000000044, 1.1097362711751553, 0.1799420024081277, 0.7651328146241045], "isController": false}, {"data": ["Update Education", 200, 0, 0.0, 141.16000000000008, 2, 488, 125.5, 194.9, 225.99999999999977, 337.18000000000075, 1.1097362711751553, 0.23962283878861187, 0.8109636221514457], "isController": false}, {"data": ["Add Language", 200, 0, 0.0, 46.315000000000026, 40, 180, 44.0, 47.900000000000006, 53.89999999999998, 133.0, 1.1108457424059808, 0.2245557311308965, 0.6548023423571036], "isController": false}, {"data": ["Add Certifications", 200, 0, 0.0, 82.55500000000002, 78, 167, 80.0, 84.9, 87.94999999999999, 165.96000000000004, 1.110432513463994, 0.22447219754594414, 0.7216726930764532], "isController": false}, {"data": ["View Manage listing", 200, 0, 0.0, 123.57500000000002, 108, 267, 120.0, 128.0, 133.0, 244.83000000000015, 1.1101428198737766, 0.46183675904905164, 0.6775774047081157], "isController": false}, {"data": ["Add Skills", 200, 0, 0.0, 43.77999999999997, 39, 126, 42.0, 46.0, 50.94999999999999, 92.76000000000022, 1.1103153850851335, 0.22444852022717054, 0.6895232028157599], "isController": false}, {"data": ["Delete Certifications", 200, 0, 0.0, 42.794999999999995, 36, 129, 40.0, 44.0, 52.849999999999966, 124.92000000000007, 1.1106668443733618, 0.22079384392076504, 0.6529506253054334], "isController": false}, {"data": ["SignIn", 200, 0, 0.0, 162.45000000000002, 143, 369, 155.0, 172.9, 226.59999999999945, 350.60000000000036, 1.1101736311559127, 0.5334037368444425, 0.38379049358319645], "isController": false}, {"data": ["Update Language", 200, 0, 0.0, 163.44499999999996, 146, 381, 157.0, 168.8, 198.79999999999973, 331.95000000000005, 1.110192118746149, 0.23309697805705276, 0.7088966980110908], "isController": false}, {"data": ["Toggle Checkbox", 200, 0, 0.0, 117.33000000000004, 98, 207, 115.0, 124.9, 128.0, 206.98000000000002, 1.1101181720794178, 0.20597895771004823, 0.6526280660076265], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 28, 100.0, 0.7], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 4000, 28, "500/Internal Server Error", 28, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certifications", 200, 28, "500/Internal Server Error", 28, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
