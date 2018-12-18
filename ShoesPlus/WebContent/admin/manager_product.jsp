<%@page import="model.Product"%>
<%@page import="java.util.ArrayList"%>
<%@page import="dao.ProductDAO"%>
<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Quản lý sản phẩm</title>
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
		ProductDAO productDAO = new ProductDAO();
		ArrayList<Product> list = productDAO.getListProduct();
	%>
	<jsp:include page="header.jsp"></jsp:include>
	
	<div id="wrapper">
		<jsp:include page="menu.jsp"></jsp:include>
		<div id="rightContent">
		<h3>Quản lý sản phẩm</h3>
		<a href="insert_product"> Thêm sản phẩm</a>
		<table class="data">
			<tr class="data">
				<th class="data" width="30px">STT</th>
				<th class="data">Mã sản phẩm</th>
				<th class="data">Tên sản phẩm</th>
				<th class="data">Giá</th>
				<th class="data" width="90px">Tùy chọn</th>
			</tr>
			<%
				int count = 0;
				for(Product p : list) {
					count++;
			%>
			<tr class="data">
				<td class="data" width="30px"><%=count %></td>
				<td class="data"><%=p.getProductID() %></td>
				<td class="data"><%=p.getProductName() %></td>
				<td class="data"><%=p.getPrice() %></td>
				<td class="data" width="90px">
				<center>
					<a href="${root}/admin/update_category.jsp?command=update&categoryID=">Sửa</a>&nbsp;&nbsp; | &nbsp;&nbsp;
					<a href="/PhonesPlus/ManagerCategoryServlet?command=delete&categoryID=">Xóa</a>
				</center>
				</td>
			</tr>
			<%
				}
			%>
		</table>
	</div>
	<div class="clear"></div>		
		<jsp:include page="footer.jsp"></jsp:include>
	</div>
</body>
</html>