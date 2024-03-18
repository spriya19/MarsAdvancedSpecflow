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

    var data = {"OkPercent": 99.4, "KoPercent": 0.6};
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
    createTable($("#apdexTable"), {"supportsControllersDiscrimination": true, "overall": {"data": [0.96875, 500, 1500, "Total"], "isController": false}, "titles": ["Apdex", "T (Toleration threshold)", "F (Frustration threshold)", "Label"], "items": [{"data": [1.0, 500, 1500, "Signout"], "isController": false}, {"data": [1.0, 500, 1500, "Share Skill Add"], "isController": false}, {"data": [1.0, 500, 1500, "Update Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Add Educatiom"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Education"], "isController": false}, {"data": [0.5, 500, 1500, "Categories"], "isController": false}, {"data": [0.9983333333333333, 500, 1500, "Add Description"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Language Request"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Manage Listing"], "isController": false}, {"data": [0.88, 500, 1500, "Update Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "Update Education"], "isController": false}, {"data": [1.0, 500, 1500, "Add Language"], "isController": false}, {"data": [0.9983333333333333, 500, 1500, "Add Certifications"], "isController": false}, {"data": [1.0, 500, 1500, "View Manage listing"], "isController": false}, {"data": [1.0, 500, 1500, "Add Skills"], "isController": false}, {"data": [1.0, 500, 1500, "Delete Certifications"], "isController": false}, {"data": [0.9983333333333333, 500, 1500, "SignIn"], "isController": false}, {"data": [1.0, 500, 1500, "Update Language"], "isController": false}, {"data": [1.0, 500, 1500, "Toggle Checkbox"], "isController": false}]}, function(index, item){
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
    createTable($("#statisticsTable"), {"supportsControllersDiscrimination": true, "overall": {"data": ["Total", 6000, 36, 0.6, 139.57983333333365, 1, 1227, 114.0, 191.0, 817.0, 851.0, 23.718414977388445, 11.358376016185842, 15.750807198193053], "isController": false}, "titles": ["Label", "#Samples", "FAIL", "Error %", "Average", "Min", "Max", "Median", "90th pct", "95th pct", "99th pct", "Transactions/s", "Received", "Sent"], "items": [{"data": ["Signout", 300, 0, 0.0, 40.10333333333334, 33, 146, 40.0, 43.0, 44.0, 50.97000000000003, 1.2061077295424028, 0.23792359508551303, 0.6372112125805076], "isController": false}, {"data": ["Share Skill Add", 300, 0, 0.0, 85.35999999999994, 73, 374, 80.0, 86.90000000000003, 92.0, 341.98, 1.2045677207972632, 0.26349918892440133, 1.9727149099384869], "isController": false}, {"data": ["Update Skills", 300, 0, 0.0, 162.17999999999998, 137, 343, 160.0, 174.0, 179.0, 245.96000000000004, 1.2041084179219497, 0.24340863526351914, 0.7783275285273353], "isController": false}, {"data": ["Add Educatiom", 300, 0, 0.0, 113.26666666666667, 71, 396, 114.5, 148.90000000000003, 157.95, 329.38000000000056, 1.2041857496658386, 0.24367513978589578, 0.8310841610437882], "isController": false}, {"data": ["Delete Education", 300, 0, 0.0, 41.243333333333325, 2, 146, 41.0, 45.0, 46.0, 63.8900000000001, 1.204722512248012, 0.2564898150750944, 0.7032881395068669], "isController": false}, {"data": ["Categories", 300, 0, 0.0, 846.0599999999995, 817, 1227, 839.0, 861.0, 876.8, 1095.6500000000003, 1.2020531067062543, 6.353038489740476, 0.872192830354245], "isController": false}, {"data": ["Add Description", 300, 0, 0.0, 124.1333333333334, 100, 695, 121.0, 131.90000000000003, 134.95, 202.98000000000002, 1.20437428741188, 0.25875228831114605, 0.724506407271209], "isController": false}, {"data": ["Delete Skills", 300, 0, 0.0, 42.46666666666667, 34, 136, 41.0, 45.0, 46.0, 123.54000000000042, 1.2047321880345998, 0.2250166780112281, 0.781083721859464], "isController": false}, {"data": ["Delete Language Request", 300, 0, 0.0, 42.90333333333332, 34, 132, 41.0, 45.0, 51.89999999999998, 126.90000000000009, 1.204761216326924, 0.2355951344714311, 0.7023852013155992], "isController": false}, {"data": ["Delete Manage Listing", 300, 0, 0.0, 162.86666666666667, 149, 343, 160.0, 170.90000000000003, 179.84999999999997, 303.41000000000054, 1.2055115990307685, 0.22250165255548368, 0.7063544525570911], "isController": false}, {"data": ["Update Certifications", 300, 36, 12.0, 191.19000000000008, 111, 403, 197.0, 210.0, 215.95, 327.3200000000006, 1.2039199634008333, 0.1967186408947533, 0.8299875958621271], "isController": false}, {"data": ["Update Education", 300, 0, 0.0, 145.74666666666673, 1, 382, 151.0, 194.90000000000003, 210.95, 273.98, 1.2037605479518014, 0.26073249707084933, 0.8793995880631091], "isController": false}, {"data": ["Add Language", 300, 0, 0.0, 46.45999999999998, 37, 330, 44.0, 49.0, 51.94999999999999, 133.99, 1.2020820060344517, 0.24299899926672996, 0.7085709949632764], "isController": false}, {"data": ["Add Certifications", 300, 0, 0.0, 84.87333333333332, 75, 817, 82.0, 87.90000000000003, 90.0, 125.74000000000024, 1.2045241928684138, 0.24349268351929848, 0.7828230960487591], "isController": false}, {"data": ["View Manage listing", 300, 0, 0.0, 123.46000000000001, 104, 322, 121.0, 132.0, 135.0, 231.73000000000025, 1.2057732422840561, 0.501620508997078, 0.7359455824487647], "isController": false}, {"data": ["Add Skills", 300, 0, 0.0, 44.81000000000001, 37, 283, 42.0, 48.0, 49.94999999999999, 99.75000000000023, 1.2047128366168451, 0.24353081755828804, 0.748153338359663], "isController": false}, {"data": ["Delete Certifications", 300, 0, 0.0, 42.07666666666669, 33, 126, 41.0, 45.0, 47.94999999999999, 122.44000000000051, 1.2047176744130013, 0.23964940456828943, 0.7082422265592059], "isController": false}, {"data": ["SignIn", 300, 0, 0.0, 169.35333333333347, 153, 634, 164.0, 179.0, 187.95, 265.93000000000006, 1.1992516669598172, 0.5762029493595996, 0.414585048929468], "isController": false}, {"data": ["Update Language", 300, 0, 0.0, 163.6833333333332, 137, 466, 159.0, 174.0, 182.95, 290.9200000000001, 1.2028772824596436, 0.2525572419226791, 0.768099011585713], "isController": false}, {"data": ["Toggle Checkbox", 300, 0, 0.0, 119.36000000000004, 108, 223, 117.0, 126.0, 131.95, 204.99, 1.2057053979430665, 0.22371486875896743, 0.7088228999626232], "isController": false}]}, function(index, item){
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
    createTable($("#errorsTable"), {"supportsControllersDiscrimination": false, "titles": ["Type of error", "Number of errors", "% in errors", "% in all samples"], "items": [{"data": ["500/Internal Server Error", 36, 100.0, 0.6], "isController": false}]}, function(index, item){
        switch(index){
            case 2:
            case 3:
                item = item.toFixed(2) + '%';
                break;
        }
        return item;
    }, [[1, 1]]);

        // Create top5 errors by sampler
    createTable($("#top5ErrorsBySamplerTable"), {"supportsControllersDiscrimination": false, "overall": {"data": ["Total", 6000, 36, "500/Internal Server Error", 36, "", "", "", "", "", "", "", ""], "isController": false}, "titles": ["Sample", "#Samples", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors", "Error", "#Errors"], "items": [{"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": ["Update Certifications", 300, 36, "500/Internal Server Error", 36, "", "", "", "", "", "", "", ""], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}, {"data": [], "isController": false}]}, function(index, item){
        return item;
    }, [[0, 0]], 0);

});
