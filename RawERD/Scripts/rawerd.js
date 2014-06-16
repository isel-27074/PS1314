
(function () {

    $(document).ready(function() {
        var graph = new joint.dia.Graph;

        var paper = new joint.dia.Paper({
            el: $('#paper'),
            width: 800,
            height: 600,
            gridSize: 1,
            model: graph
        });

        var erd = joint.shapes.erd;

        var element = function(elm, x, y, label) {
            var cell = new elm({ position: { x: x, y: y }, attrs: { text: { text: label }}});
            graph.addCell(cell);
            return cell;
        };

        var link = function(elm1, elm2) {
            var myLink = new erd.Line({ source: { id: elm1.id }, target: { id: elm2.id }});
            graph.addCell(myLink);
            return myLink;
        };

        var employee = element(erd.Entity, 100, 200, "Employee");
        var salesman = element(erd.Entity, 100, 400, "Salesman");
        var wage = element(erd.WeakEntity, 530, 200, "Wage");
        var paid = element(erd.IdentifyingRelationship, 350, 190, "gets paid");
        var isa = element(erd.ISA, 125, 300, "ISA");
        var number = element(erd.Key, 0, 90, "number");
        var nameEl = element(erd.Normal, 75, 30, "name");
        var skills = element(erd.Multivalued, 150, 90, "skills");
        var amount = element(erd.Derived, 440, 80, "amount");
        var date = element(erd.Normal, 590, 80, "date");
        var plate = element(erd.Key, 405, 500, "plate");
        var car = element(erd.Entity, 430, 400, "Company car");
        var uses = element(erd.Relationship, 300, 390, "uses");

        link(employee, paid).cardinality('1');
        link(employee, number);
        link(employee, nameEl);
        link(employee, skills);
        link(employee, isa);
        link(isa, salesman);
        link(salesman, uses).cardinality('0..1');
        link(car, uses).cardinality('1..1');
        link(car, plate);
        link(wage, paid).cardinality('N');
        link(wage, amount);
        link(wage, date);

        $("#dialogNewEntity").dialog({
            resizable: false,
            height:140,
            modal: true,
            autoOpen: false,
            buttons: {
                "Ok": function() {
                    var entity = new Entity($("#txbEntityName").val());
                    Model.entities.push(entity);
                    element(erd.Entity, 100, 200, entity.name);
                    $(this).dialog("close");
                },
                "Cancelar": function() {
                    $(this).dialog("close");
                }
            }
        });

        $("#dialogAddAttribute").dialog({
            resizable: false,
            height:140,
            modal: true,
            autoOpen: false,
            buttons: {
                "Ok": function() {
                    var selectedEntityName = $("#cmbEntities option:selected").text();
                    for(var i = 0; i < Model.entities.length; ++i) {
                        var entity = Model.entities[i];
                        if (entity.name == selectedEntityName) {
                            entity.addAttribute($("#attributeName").val());
                            var nameEl = element(erd.Normal, 75, 30, "name");
                        }
                    }

                    var entity = new Entity($("#txbEntityName").val());
                    Model.entities.push(entity);
                    element(erd.Entity, 100, 200, entity.name);
                    $(this).dialog("close");
                },
                "Cancelar": function() {
                    $(this).dialog("close");
                }
            }
        });

        $("#addEntity").click(function() {
            $("#dialogNewEntity").dialog("open");
        });

        $("#addAttribute").click(function() {
            var cmb = $("#cmbEntities");
            $.each(Model.entities, function(i, o) {
                cmb.append($("<option />").val(i).text(o.name));
            });
            $("#dialogAddAttribute").dialog("open");

        });
    });


    var Model = {
        entities: []
    };





    /**
     * Entity constructor.
     * @param name Entity name.
     */
    function Entity(name) {

        this.id = 0;
        this.name = name;
        this.attributes = [];
        this.associations = [];
    }

    Entity.create = function(name) {
        var entity = new Entity(name);
        return entity;
    }

    Entity.prototype = {
        constructor: Entity,    // When we replace the prototype, this property is lost,
                                // so we set it back. Not really needed, though...

        addAttribute: function(name, dataType) {
            var attribute = new Attribute(this, name, dataType);
            this.attributes.push(attribute);
        }
    }

    function Attribute(entity, name, dataType) {
        this.id = 0;
        this.name = name;
        this.entity = entity;
        this.dataType = dataType;
    }

    Attribute.prototype = {
        constructor: Attribute // When we replace the prototype, this property is lost,
                               // so we set it back. Not really needed, though...

    }

    var Cardinality = {
        One: "one",
        Many: "many"
    }

    var Participation = {
        Optional: "optional",
        Mandatory: "mandatory"
    }

    function AssociationEndpoint(entity, cardinality, participation) {
        this.entity = entity;
        this.cardinality = cardinality;
        this.participation = participation;
    }

    function Association(name, endpoint1, endpoint2) {
        this.id = 0;
        this.name = name;
        this.endpoint1 = endpoint1;
        this.endpoint2 = endpoint2;
        this.attributes = [];
    }

    Association.prototype = {
        constructor: Association,   // When we replace the prototype, this property is lost,
        // so we set it back. Not really needed, though...

        addAttribute: function(name, dataType) {
            var attribute = new Attribute(this, name, dataType);
            this.attributes.push(attribute);
        }
    }
})();