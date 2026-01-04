import { createSystem, defaultConfig, defineConfig } from "@chakra-ui/react"

const customConfig = defineConfig({
  theme: {
    tokens: {
      colors: {
        brand: {
          50: { value: "#eef2ff" },
          100: { value: "#e0e7ff" },
          200: { value: "#c7d2fe" },
          300: { value: "#a5b4fc" },
          400: { value: "#818cf8" },
          500: { value: "#6366f1" },
          600: { value: "#4f46e5" },
          700: { value: "#4338ca" },
          800: { value: "#3730a3" },
          900: { value: "#312e81" },
        },
      },
      radii: {
        card: { value: "16px" },
        button: { value: "12px" },
      },
    },
    semanticTokens: {
      colors: {
        bg: {
          main: {
            value: { base: "linear-gradient(180deg, #f8faff 0%, #ffffff 100%)", _dark: "linear-gradient(180deg, #0f172a 0%, #020617 100%)" }
          },
          glass: {
            value: { base: "rgba(255, 255, 255, 0.7)", _dark: "rgba(15, 23, 42, 0.7)" }
          },
          card: {
            value: { base: "#ffffff", _dark: "#1e293b" }
          }
        },
        text: {
          primary: {
            value: { base: "#1e293b", _dark: "#f1f5f9" }
          },
          secondary: {
            value: { base: "#64748b", _dark: "#94a3b8" }
          },
          brand: {
            value: { base: "#4f46e5", _dark: "#818cf8" }
          }
        },
        border: {
          subtle: {
            value: { base: "rgba(226, 232, 240, 0.8)", _dark: "rgba(51, 65, 85, 0.8)" }
          }
        }
      },
      shadows: {
        soft: {
          value: { 
            base: "0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06)", 
            _dark: "0 4px 6px -1px rgba(0, 0, 0, 0.4), 0 2px 4px -1px rgba(0, 0, 0, 0.2)" 
          }
        },
        cardHover: {
          value: {
            base: "0 20px 25px -5px rgba(0, 0, 0, 0.1), 0 10px 10px -5px rgba(0, 0, 0, 0.04)",
            _dark: "0 20px 25px -5px rgba(0, 0, 0, 0.5), 0 10px 10px -5px rgba(0, 0, 0, 0.3)"
          }
        }
      }
    }
  }
})

export const system = createSystem(defaultConfig, customConfig)
