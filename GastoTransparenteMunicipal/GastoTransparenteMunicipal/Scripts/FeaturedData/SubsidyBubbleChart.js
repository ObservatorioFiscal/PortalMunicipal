var localeFormatter = d3.formatLocale({
    "decimal": ",",
    "thousands": "."    
});

var diameter = 700;    
    //format = localeFormatter.format(",.0f"), //ya no se usa si datos editar un html
    //color = d3.scaleOrdinal(d3.schemeCategory20c);


var bubble = d3.pack()
    .size([diameter, diameter])
    .padding(1.5);

var svg = d3.select("#chart").append("svg")
    .attr("width", diameter)
    .attr("height", diameter)
    .attr("class", "bubble");

var lateralPanel = d3.select("#lateralPanel").append("ul");

var currentMunicipality = "municipalidad";
var url = "/" + currentMunicipality + "/FeaturedData/SubsidyAjax";

d3.json(url, function (error, data) {
    if (error)
        throw error;

    var minColor = "#d5ebf7";
    var maxColor = "#285685";
    var colorlist = [minColor, maxColor];
    //var functionlist = [d3.interpolateRgb, d3.interpolateHsl, d3.interpolateHcl];
  
    var limitRange = data.children.length;    
    var vectorColor = (
         d3.scaleLinear()
        .domain([0, limitRange])
            .interpolate(d3.interpolateRgb)
        .range([colorlist[0], colorlist[1]])
    );     

    var root = d3.hierarchy(classes(data))
        .sum(function (d) { return d.value; })
        .sort(function (a, b) { return b.value - a.value; });

    bubble(root);
    var node = svg.selectAll(".node")
        .data(root.children)
        .enter().append("g")
        .attr("class", "node")
        .attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; })    
        .on("mouseover", function (d) {            

            var tooltip = d3.select("#tooltip");
            tooltip.style("left", d3.event.pageX + "px");
            tooltip.style("top", d3.event.pageY + "px");
            tooltip.select("#monto").text(d.data.value);
            tooltip.select("#clasificacion").text(d.data.className);

			d3.select("#tooltip").classed("hidden", false);
		})
		.on("mouseout", function() {
			d3.select("#tooltip").classed("hidden", true);

		});

    node.append("circle")
        .attr("r", function (d) { return d.r; })
        .style("fill", function (d) {            
            var colorPosition = d.data.orderDescPosition;
            var li = lateralPanel.append("li").attr("style","list-style-type: none");
            li.append("i").attr("class","fa fa-circle").attr("style", "color:" + vectorColor(colorPosition));
            li.append("label").text(d.data.className);
            return vectorColor(colorPosition);
        });

    node.append("text")
        .attr("dy", ".3em")
        .style("text-anchor", "middle")
        .text(function (d) { return d.data.className.substring(0, d.r / 3); });
});

// Returns a flattened hierarchy containing all leaf nodes under the root.
function classes(root) {
    var classes = [];

    function recurse(name, node) {
        if (node.children) node.children.forEach(function (child) { recurse(node.name, child); });
        else classes.push({ packageName: name, className: node.name, value: node.size, orderDescPosition: node.position});
    }

    recurse(null, root);
    return { children: classes };
}

d3.select(self.frameElement).style("height", diameter + "px");


