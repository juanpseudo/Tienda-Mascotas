function cargarMenu() {
    $(document).ready(function () {
        $("#jqxMenu").jqxMenu({
            width: "100%",
            theme: 'energyblue',
            height: 40
        });
    });
}

function crearMenuLateral(idpadredescrip) {
    mostrarProductos(idpadredescrip);
    //var jsonHTML = { idpadredescrip: idpadredescrip }
    //$.ajax({
    //    type: "POST",
    //    contentType: "application/json; charset=utf-8",
    //    url: "index.aspx/crearMenuLateral",
    //    dataType: "json",
    //    data: JSON.stringify(jsonHTML),
    //    success: function (data, status) {
    //        console.log(data);
    //        var obj = data.d;
    //        if (obj != '') {
    //            var html = "";
    //            var cont = 0;
    //            var largo = obj.length;
    //            html += "<div class='titulo_menu_lateral'> CATEGORIA </div>"
    //            while (cont < largo) {
                    
    //                html += "<input type='checkbox' name='"+obj[cont].nomdescrip+"' value='" + obj[cont].idparametrodescrip + "'>" + obj[cont].nomdescrip + "<br>";
    //                cont++;
    //            }
    //            $("#menu_principal_dv_menu_lateral").html(html);
               
               



    //        }
    //    },
    //    error: function (result, textStatus, quepaso) {
    //        alert(quepaso);
    //    }
    //});



        //$("#jqxMenuVertical").jqxMenu({
        //    mode: "vertical",
        //    width: 250
        //});
}



function crearMenuPrincipal(v_var1) {

    $("div[id='tabs_infra_2'] div[id='tabs_Torre'] div[id='tabs_Torre_1'] div[id='INFRAESTRUCTURAM_TORRE_FRM_jqxWidget_infra_torre_list']").html('<div id="jqxGrid_infra_torre_list"></div>');
    $("div[id='tabs_infra_2'] div[id='tabs_Torre'] div[id='tabs_Torre_1'] div[id='INFRAESTRUCTURAM_TORRE_FRM_jqxWidget_infra_torre_list'] div[id='jqxGrid_infra_torre_list']").jqxGrid('destroy');

    var contenedor = $("div[id='tabs_infra_2'] div[id='tabs_Torre'] div[id='tabs_Torre_1'] div[id='INFRAESTRUCTURAM_TORRE_FRM_jqxWidget_infra_torre_list'] div[id='jqxGrid_infra_torre_list']");

    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "menu_forms/infraestructura/frm_acciones.aspx/ObtDatos_TORRE",
        dataType: "json",
        data: "{'id_proyecto' : '" + $.trim(v_var1) + "'}",
        beforeSend: function () {
            $(contenedor).html("<div align='center' style='background-color: #fff; height: 82px;'><img src='imagenes/cargando.gif'></div>");
        },
        success: function (data) {
            var obj = data.d;

            if (obj != '') {
                var datosJSON = obj;

                var source =
                {
                    datatype: "json",
                    datafields: [
                        { name: 'ID_FORM', type: 'string' },
                        { name: 'ID_PROYECTO', type: 'string' },
                        { name: 'TIPO_ESTRUCTURA', type: 'string' },
                        { name: 'ALTURA_TORRE', type: 'string' },
                        { name: 'CANT_TOTAL_SOP', type: 'string' },
                        { name: 'CANT_DISP_SOP', type: 'string' },
                        { name: 'CANT_INST_SOP', type: 'string' },
                        { name: 'ALTURA_INST_SOP', type: 'string' },
                        { name: 'PARARRAYO', type: 'string' },
                        { name: 'INST_BALIZA', type: 'string' },
                        { name: 'INST_ATERR_ESA', type: 'string' },
                        { name: 'ESTRUCTURA_SOP_ANT', type: 'string' },
                        { name: 'REQ_LIVES', type: 'string' },
                        { name: 'DESC_TIPO_ESTRUCTURA', type: 'string' },
                        { name: 'DESC_PARARRAYO', type: 'string' },
                        { name: 'DESC_INST_BALIZA', type: 'string' },
                        { name: 'DESC_INST_ATERR_ESA', type: 'string' },
                        { name: 'DESC_ESTRUCTURA_SOP_ANT', type: 'string' },
                        { name: 'DESC_REQ_LIVES', type: 'string' },
                        { name: 'DESC_FOTOS_PAR', type: 'string' },
                        { name: 'DESC_FOTOS_BAL_INST', type: 'string' },
                        { name: 'DESC_FOTOS_ATER', type: 'string' },
                        { name: 'DESC_FOTOS_AEREA', type: 'string' },
                        { name: 'DESC_FOTOS_NIVEL', type: 'string' },
                        { name: 'DESC_FOTOS_TORRE', type: 'string' }
                    ],
                    localdata: datosJSON
                };

                var editcellrenderer = function (row, column, value, defaultHtml) {
                    //var rowAddedByEmpID = $('#jqxStatusGrid').jqxGrid('getcellvalue', row, 'AddedByEmpID');
                    var datarecord = $(contenedor).jqxGrid('getrowdata', row);

                    datarecord.USUARIODIG = $.trim($(dir_usuariodig).text());
                    datarecord.TIPO_FORM = $.trim($(dir_tipo_form).val());

                    return '<div style="margin-top: 4px;" align="center">' +
                            '    <button type="button" title="Editar torre"  onclick="Open_Modal(850, 500, \'InsertarTorre(2,&quot;' + btoa(JSON.stringify(datarecord)) + '&quot;)\')"  class="btn btn-info btn-xs">' +
                            '        <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>' +
                            '    </button>&nbsp;' +
                            "    <button type='button' title='Eliminar torre'  onclick='Confirm_Modal(\"\",\"EliminarRegistroTorre(" + datarecord.ID_PROYECTO + "," + datarecord.ID_FORM + ")\")'   class='btn btn-danger btn-xs'>" +
                            '        <span class="glyphicon glyphicon-trash" aria-hidden="true"></span>' +
                            '    </button>' +
                            '</div>';

                }

                var dataAdapter = new $.jqx.dataAdapter(source);

                $(contenedor).jqxGrid(
                {
                    width: "100%",
                    height: "212px",
                    theme: 'metro',
                    source: dataAdapter,
                    pageable: true,
                    autoheight: false,
                    sortable: true,
                    enabletooltips: true,
                    filterable: true,
                    showfilterrow: true,
                    pagesize: 5,
                    pagesizeoptions: ['5'],
                    columns: [
                        { text: 'Tipo estructura', datafield: 'DESC_TIPO_ESTRUCTURA', width: "180px" },
                        { text: 'Altura', datafield: 'ALTURA_TORRE', width: "70px" },
                        { text: 'Cant. total soportes', datafield: 'CANT_TOTAL_SOP', width: "120px" },
                        { text: 'Cant. soportes disp.', datafield: 'CANT_DISP_SOP', width: "120px" },
                        { text: 'Cant. soportes inst.', datafield: 'CANT_INST_SOP', width: "120px" },
                        { text: 'Altura soportes inst.', datafield: 'ALTURA_INST_SOP', width: "100px" },
                        { text: 'Pararrayo', datafield: 'DESC_PARARRAYO', width: "80px" },
                        { text: 'Inst. baliza', datafield: 'DESC_INST_BALIZA', width: "80px" },
                        { text: 'Inst. aterramiento E.S.A.', datafield: 'DESC_INST_ATERR_ESA', width: "100px" },
                        { text: 'Fotos estructura soportante antenas', datafield: 'DESC_ESTRUCTURA_SOP_ANT', width: "120px" },
                        { text: 'LVES', datafield: 'DESC_REQ_LIVES', width: "120px" },
                        { text: '', datafield: 'Editar', width: 100, pinned: true, cellsalign: 'center', filterable: false, sortable: false, menu: false, cellsrenderer: editcellrenderer }
                    ]
                });

            } else {

                $(contenedor).html("<div class='alert-box error_box'><span>ERROR : </span>No se encontraron resultados.</div>");
            }

        },
        error: function (result) {
            alert(result);
        }
    });


}


//<img src="../../fonts/imagenesProductos/37_1.png" />
function mostrarProductos(idCLase) {
    $("div[id='dv_main']").html('<div id="jqxWidget_productos"></div>');
    $("div[id='dv_main'] div[id='jqxWidget_productos']").jqxGrid('destroy');
    var contenedor = $("div[id='dv_main'] div[id='jqxWidget_productos']");
    var datos = { idCLase: idCLase }
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: "index.aspx/crearMenuPrincipal",
        dataType: "json",
        data: JSON.stringify(datos), 
        success: function (data) {
            console.log(data);
            var obj = data.d;
            if (obj != '') {
                console.log(obj);
                var data = obj;
                var source =
                {
                    datatype: "json",
                    datafields: [
                        { name: 'imagen_url', type: 'string' },
                        { name: 'nom_produc', type: 'string' },
                        { name: 'descrip_produ', type: 'string' },
                        { name: 'precioproductogen', type: 'int' }
                        //,
                        //{ name: 'ID_PROYECTO', type: 'string' },
                        //{ name: 'ID_FORM', type: 'string' },
                        //{ name: 'TIPO_FORM', type: 'string' },
                        //{ name: 'IMAGEN', type: 'string' },
                        //{ name: 'OBSERVACION', type: 'string' },
                        //{ name: 'FECHADIG', type: 'string' },
                        //{ name: 'USUARIODIG', type: 'string' },
                        //{ name: 'TIPO_IMAGEN', type: 'string' },
                        //{ name: 'URL_IMAGEN', type: 'string' },
                        //{ name: 'URL_IMAGEN_2', type: 'string' }
                    ],
                    localdata: data
                };

                var dataAdapter = new $.jqx.dataAdapter(source);

                var imagerenderer = function (row, datafield, value) {
                    return '<img style="margin-left: 5px;" height="100" width="100" src="' + value + '"/>';
                }

                var btnImg = function (row, datafield, verImg) {
                    return '<div style="text-align: center; margin: 0 auto; line-height: 100px;"><button type="button" class="btn btn-success btn-xs"  onclick="verImg(&quot;' + verImg + '&quot;)"><span class="glyphicon glyphicon-zoom-in" aria-hidden="true"></span> Ver Detalle</button></div>';
                }

                $(contenedor).jqxGrid(
                {
                    width: '98%',
                   // columnsheight: 200,
                    height: '500px;',
                    theme: 'energyblue',
                    source: dataAdapter,
                    pageable: true,
                    autoheight: false,
                    sortable: true,
                    enabletooltips: true,
                    filterable: true,
                    autorowheight: true,
                    showfilterrow: true,
                    //pageable: true,
                    //pagesize: 2,
                    columns: [
                        	                      
	                      { text: 'Foto', datafield: 'imagen_url', width: 100, cellsrenderer: imagerenderer },
                          { text: 'Nombre', datafield: 'nom_produc', width: 300 },
                          { text: 'Descripción', datafield: 'descrip_produ'},
                          { text: 'Precio', datafield: 'precioproductogen', width: 100, cellsformat: 'c3' },
                          { text: 'Detalle', filterable:false, width: 170, cellsrenderer: btnImg }
                    ]
                });

                var datainformations = $(contenedor).jqxGrid('getdatainformation');
                var rowscounts = datainformations.rowscount;

                for (m = 0; m < rowscounts; m++) {
                    $(contenedor).jqxGrid('setrowheight', m, 100);
                }
            }
        },
        error: function (result) {
            alert(result);
        }
    });
}
