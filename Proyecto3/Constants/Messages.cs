namespace Proyecto3.Constants
{
    public class Messages
    {
        public static class Success
        {
            // Creación
            public const string CustomersCreated = "Cliente registrado exitosamente";
            public const string DirectionsCreated = "Direccion agregada exitosamente.";
            public const string RecordCreated = "Registro agregado exitosamente";

            // Actualización
            public const string CustomersUpdated = "Cliente actualizado exitosamente";
            public const string DirectionsUpdated = "Direccion actualizada exitosamente.";
            public const string RecordUpdated = "Registro actualizado exitosamente";
            // Eliminación
            public const string CustomersDeleted = "Cliente eliminado exitosamente";
            public const string DirectionsDeleted = "Direccion eliminado exitosamente.";
            public const string RecordDeleted = "Registro eliminado exitosamente";
        }
        public static class Error
        {
            // Búsqueda/Existencia
            public const string CustomersNotFoundWithId = "Cliente con ID {0} no encontrado";
            public const string DirectionsNotFound = "Direccion no encontrada";
            public const string DetailNotFound = "No se encontro el detalle";

            // Creación
            public const string CustomersCreateError = "Hubo un error al agregar el cliente";
            public const string DirectionsCreateError = "Hubo un error al agregar la direccion";
            public const string RecordCreatedError = "Error al crear el registro";

            // Actualización
            public const string CustomersUpdateError = "Error al actualizar el cliente";
            public const string DirectionsUpdateError = "Error al actualizar la direccion";
            public const string RecordUpdateError = "Error al actualizar la direccion";

            // Eliminación
            public const string CustomersDeleteError = "Error al eliminar el cliente";
            public const string DirectionsDeleteError = "Error al eliminar la direccion";
            public const string RecordDeleteError = "Error al eliminar el registro";
        }
        public static class Validation
        {
            public const string UnSupportedFileType = "El tipo de archivo no es soportado.";
        }
        public static class Info
        {
        }
    }
}
