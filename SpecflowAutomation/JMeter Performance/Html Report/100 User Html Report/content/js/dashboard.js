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

    var data = {"OkPercent": 99.25, "KoPercent": 0.75};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.967, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Signout"], "isController": false}, {"data": [0.995, 500, 1500, "Share Skill Add"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Add Educatiom"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.5, 500, 1500, "Categories"], "isController": false}, {"data": [1.0, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Manage Listing"], "isController": false}, {"data": [0.85, 500, 1500, "Update Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [0.995, 500, 1500, "Add Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "View Manage listing"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Toggle Checkbox"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 2000, 15, 0.75, 144.0585, 1, 1378, 107.0, 204.0, 790.5499999999984, 884.99, 22.659038123831643, 10.844418707160257, 15.046342601115958], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Signout", 100, 0, 0.0, 43.790000000000006, 33, 149, 39.5, 46.0, 57.69999999999993, 148.99, 1.1849323996066023, 0.23374643039114618, 0.6260238556515351], "isController": false}, {"data": ["Share Skill Add", 100, 0, 0.0, 93.85999999999999, 66, 741, 80.0, 97.70000000000002, 161.89999999999952, 737.0199999999979, 1.1805817907064602, 0.25825226671703816, 1.933433264662826], "isController": false}, {"data": ["Update Skills", 100, 0, 0.0, 169.10000000000005, 135, 400, 161.0, 185.70000000000002, 250.64999999999992, 399.6399999999998, 1.1796208698524293, 0.23845851568305948, 0.7620650332358181], "isController": false}, {"data": ["Add Educatiom", 100, 0, 0.0, 84.25, 71, 194, 80.0, 89.0, 132.5999999999999, 193.87999999999994, 1.1806793629054158, 0.23867248839982524, 0.8149339520585145], "isController": false}, {"data": ["Delete Education", 100, 0, 0.0, 44.120000000000005, 34, 129, 42.0, 48.900000000000006, 54.94999999999999, 128.95, 1.1819632409432066, 0.25162889309142483, 0.6902480645351929], "isController": false}, {"data": ["Categories", 100, 0, 0.0, 866.4100000000002, 782, 1378, 844.0, 979.8000000000001, 1051.2999999999997, 1376.3799999999992, 1.172250486483952, 6.195526985206199, 0.8505684682202893], "isController": false}, {"data": ["Add Description", 100, 0, 0.0, 126.16000000000003, 101, 332, 120.0, 138.70000000000002, 205.84999999999997, 331.12999999999954, 1.1805957286046538, 0.2536436135674061, 0.7102021179887371], "isController": false}, {"data": ["Delete Skills", 100, 0, 0.0, 41.75000000000001, 34, 131, 40.0, 46.900000000000006, 48.94999999999999, 130.22999999999962, 1.180930336919425, 0.22014432813920806, 0.7652174867735803], "isController": false}, {"data": ["Delete Language Request", 100, 0, 0.0, 44.47, 35, 150, 41.0, 48.0, 54.94999999999999, 149.89999999999995, 1.1809582295074224, 0.23050597786293797, 0.6885078740389952], "isController": false}, {"data": ["Delete Manage Listing", 100, 0, 0.0, 170.06, 136, 402, 157.0, 187.0, 266.74999999999994, 401.72999999999985, 1.1846095526914329, 0.21864375533074298, 0.6941071597801365], "isController": false}, {"data": ["Update Certifications", 100, 15, 15.0, 194.13000000000005, 107, 426, 195.5, 216.0, 265.99999999999955, 425.65999999999985, 1.179426091263991, 0.19050495653814853, 0.8134239144857112], "isController": false}, {"data": ["Update Education", 100, 0, 0.0, 180.58999999999997, 1, 397, 192.5, 230.0, 305.7999999999997, 396.98, 1.179356543070101, 0.2515922234703746, 0.8620589575077837], "isController": false}, {"data": ["Add Language", 100, 0, 0.0, 50.95000000000001, 37, 204, 43.0, 53.0, 128.84999999999997, 203.6499999999998, 1.1779256728900407, 0.23811583426585783, 0.6939293575887862], "isController": false}, {"data": ["Add Certifications", 100, 0, 0.0, 93.61000000000001, 75, 810, 82.0, 91.0, 106.79999999999995, 804.5199999999973, 1.1803727617181505, 0.23861050944888398, 0.7671270243392864], "isController": false}, {"data": ["View Manage listing", 100, 0, 0.0, 123.86, 102, 320, 120.0, 134.9, 139.89999999999998, 319.2099999999996, 1.1846095526914329, 0.49281608344389694, 0.7230282914376421], "isController": false}, {"data": ["Add Skills", 100, 0, 0.0, 45.39, 36, 158, 42.0, 47.900000000000006, 52.94999999999999, 157.8099999999999, 1.1813628201493243, 0.23881064821377943, 0.7332294472403365], "isController": false}, {"data": ["Delete Certifications", 100, 0, 0.0, 43.42, 33, 140, 40.0, 49.0, 54.0, 139.90999999999997, 1.1816140848398913, 0.23533044576391351, 0.6946598428453268], "isController": false}, {"data": ["SignIn", 100, 0, 0.0, 169.44000000000005, 145, 341, 158.5, 220.90000000000018, 277.69999999999993, 340.56999999999977, 1.1750881316098707, 0.5645931257344301, 0.40623163924794364], "isController": false}, {"data": ["Update Language", 100, 0, 0.0, 173.76999999999998, 136, 481, 159.5, 186.9, 326.6999999999995, 479.97999999999945, 1.1784670500612804, 0.24743204664372587, 0.752078337124069], "isController": false}, {"data": ["Toggle Checkbox", 100, 0, 0.0, 122.03999999999996, 101, 270, 116.0, 135.0, 198.84999999999974, 269.52999999999975, 1.1844552098262404, 0.2197719627607282, 0.6963301135892546], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 15, 100.0, 0.75], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 2000, 15, "500/Internal Server Error", 15, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certifications", 100, 15, "500/Internal Server Error", 15, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
