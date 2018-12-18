<%@page import="model.Branch"%>
<%@page import="dao.SupplierDAO"%>
<%@page import="model.Category"%>
<%@page import="dao.CategoryDAO"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Thêm sản phẩm</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="Copyright" content="arirusmanto.com">
<meta name="description" content="Admin MOS Template">
<meta name="keywords" content="Admin Page">
<meta name="author" content="Dzewyy">
<meta name="language" content="Vietnamese">

<link rel="shortcut icon" href="stylesheet/img/devil-icon.png"> 
<c:set var="root" value="${pageContext.request.contextPath}"/>
<link rel="stylesheet" type="text/css" href="${root}/admin/mos-css/mos-style.css"> 
</head>
<body>
        <%
        	CategoryDAO categoryDAO = new CategoryDAO();
                	SupplierDAO supplierDAO = new SupplierDAO();
                	String error = "";
                    if(request.getParameter("error")!=null){
                        error = (String) request.getParameter("error");
                    }
        %>
	
	<jsp:include page="header.jsp"></jsp:include>
	
	<div id="wrapper">
		<jsp:include page="menu.jsp"></jsp:include>
		
	<div id="rightContent">
	<h3>Thêm sản phẩm</h3>
		<form action="/PhonesPlus/ManagerProductServlet" method="POST">
			<table width="95%">
				<tr>
					<td width="125px"><b>Tên danh mục</b></td>
					<td>
						<select class="pendek" name="categoryID">
							<%
								for(Category c : categoryDAO.getListCategory()) {
							%>
							<option value="<%=c.getCategoryID()%>"><%=c.getCategoryName()%></option>
							<%
								}
							%>							
						</select>
						<%=error%>
					</td>
				</tr>
				<tr>
					<td width="125px"><b>Tên hãng</b></td>
					<td>
						<select class="pendek" name="supplierID">
							<%
								for(Branch s : supplierDAO.getListSupplier()) {
							%>
							<option value="<%=s.getSupplierID()%>"><%=s.getSupplierName() %></option>
							<%
								}
							%>		
						<%=error%>
					</td>
				</tr>
				<tr>
					<td width="125px"><b>Tên sản phẩm</b></td>
					<td><input type="text" class="pendek" name="productName"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Giá (đồng)</b></td>
					<td><input type="text" class="pendek" name="price" value="000"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Màn hình</b></td>
					<td><input type="text" class="pendek" name="display"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Hệ điều hành</b></td>
					<td><input type="text" class="pendek" name="oS"><%=error%></td>
				</tr>	
				<tr>
					<td width="125px"><b>Camera trước</b></td>
					<td><input type="text" class="pendek" name="fCam"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Camera sau</b></td>
					<td><input type="text" class="pendek" name="bCam"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>CPU</b></td>
					<td><input type="text" class="pendek" name="cPU"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>RAM</b></td>
					<td><input type="text" class="pendek" name="rAM"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Bộ nhớ trong</b></td>
					<td><input type="text" class="pendek" name="iStorage"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Thẻ nhớ</b></td>
					<td><input type="text" class="pendek" name="mCard"><%=error%></td>
				</tr>	
				<tr>
					<td width="125px"><b>Thẻ SIM</b></td>
					<td><input type="text" class="pendek" name="sCard"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Dung lượng pin</b></td>
					<td><input type="text" class="pendek" name="battery"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Khuyến mại</b></td>
					<td><input type="text" class="pendek" name="promotion"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Phụ kiện</b></td>
					<td><input type="text" class="pendek" name="accessory"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Bảo hành</b></td>
					<td><input type="text" class="pendek" name="warranty"><%=error%></td>
				</tr>
				<tr>
					<td width="125px"><b>Ảnh</b></td>
					<td><input type="text" class="pendek" name="image"><%=error%></td>
				</tr>		
				<tr><td></td><td>
					<input type="hidden" name="command" value="insert">
					<input type="submit" class="button" value="Lưu">
				</td></tr>
			</table>
		</form>
	</div>
	<div class="clear"></div>		
		
		<jsp:include page="footer.jsp"></jsp:include>
	</div>
</body>
</html>